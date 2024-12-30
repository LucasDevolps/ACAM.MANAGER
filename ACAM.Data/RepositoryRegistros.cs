using ACAM.Domain.DTOs;
using ACAM.Domain.Interface.Repository;
using ACAM.Mapping;
using ClosedXML.Excel;
using CsvHelper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using Npgsql;
using System.Data;
using System.Globalization;
using System.Transactions;

namespace ACAM.Data
{
    public class RepositoryRegistros : IRepositoryRegistros
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly string _caminhoImportacaoLocal;
        private string _NOME_RELATORIO;

        public RepositoryRegistros()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
            _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? "";
            _caminhoImportacaoLocal = _configuration["Configuracoes:CaminhoLocal"] ?? string.Empty;
        }
        public void ProcessarCsvPorStreaming(string caminhoCsv, int idArquivo)
        {
            using (var reader = new StreamReader(caminhoCsv))
            {
                var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    MissingFieldFound = null // Ignorar campos ausentes
                };

                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.RegisterClassMap<AcamDtoMap>();

                    csv.Read(); // Ignorar cabeçalho
                    csv.ReadHeader();

                    var buffer = new List<AcamDTO>();
                    while (csv.Read())
                    {
                        try
                        {
                            var registro = csv.GetRecord<AcamDTO>();
                            registro.Id_file = idArquivo;
                            registro.ind_positivo = Convert.ToDecimal(registro.Amount) > 0;
                            buffer.Add(registro);

                            if (buffer.Count == 1000)
                            {
                                SalvarNoBanco(buffer); // Salvar no banco em lotes
                                buffer.Clear();
                            }
                        }
                        catch (CsvHelperException ex)
                        {
                            Console.WriteLine($"Erro ao processar o registro: {ex.Message}");
                        }
                    }

                    if (buffer.Count > 0)
                    {
                        SalvarNoBanco(buffer); // Salvar qualquer dado restante
                    }
                }
            }
        }
        public void NovoProcessarCsvPorStreaming(string caminhoCsv, int idArquivo)
        {
            using (var reader = new StreamReader(caminhoCsv))
            {
                var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    MissingFieldFound = null // Ignorar campos ausentes
                };

                using (var csv = new CsvReader(reader, config))
                {
                    csv.Read(); 
                    csv.ReadHeader();

                    var buffer = new List<AcamRestritivaCAFDTO>();
                    while (csv.Read())
                    {
                        try
                        {
                            var registro = csv.GetRecord<AcamRestritivaCAFDTO>();
                            if (caminhoCsv.ToLower().Contains("positi") || !caminhoCsv.ToLower().Contains("negat"))
                            {
                                registro.ind_positivo = true;
                            }
                            else
                                registro.ind_positivo = false;
                            buffer.Add(registro);

                            if (buffer.Count == 1000)
                            {
                                NovoSalvarNoBanco(buffer); // Salvar no banco em lotes
                                buffer.Clear();
                            }
                        }
                        catch (CsvHelperException ex)
                        {
                            Console.WriteLine($"Erro ao processar o registro: {ex.Message}");
                        }
                    }

                    if (buffer.Count > 0)
                    {
                        NovoSalvarNoBanco(buffer); // Salvar qualquer dado restante
                    }
                }
            }
        }

        public void SalvarNoBanco(List<AcamDTO> buffer)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        var table = new DataTable();
                        table.Columns.Add("Client", typeof(string));
                        table.Columns.Add("Pix_Key", typeof(string));
                        table.Columns.Add("cpf_name", typeof(string));
                        table.Columns.Add("Amount", typeof(decimal));
                        table.Columns.Add("TrnDate", typeof(DateTime));
                        table.Columns.Add("id_arquivo", typeof(int));
                        table.Columns.Add("ind_positivo", typeof(bool));

                        foreach (var registro in buffer)
                        {
                            table.Rows.Add(
                                registro.Client,
                                registro.Pix_Key,
                                registro.cpf_name,
                                decimal.TryParse(registro.Amount, out var amount) ? amount : (object)DBNull.Value,
                                registro.TrnDate,
                                registro.Id_file,
                                registro.ind_positivo

                            );
                        }

                        using (var writer = connection.BeginBinaryImport("COPY AcamData (Client, Pix_Key, cpf_name, Amount, TrnDate, id_arquivo, ind_positivo) FROM STDIN (FORMAT BINARY)"))
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                writer.StartRow();
                                for (int i = 0; i < table.Columns.Count; i++)
                                {
                                    writer.Write(row[i]);
                                }
                            }
                            writer.Complete();
                        }

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = new LoggerRepository();
                logger.Log(ex);
            }
        }
        public void NovoSalvarNoBanco(List<AcamRestritivaCAFDTO> buffer)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        var table = new DataTable();
                        table.Columns.Add("ID", typeof(string));
                        table.Columns.Add("CriadoEm", typeof(DateTime));
                        table.Columns.Add("AtualizadoEm", typeof(DateTime));
                        table.Columns.Add("CriadoPor", typeof(string));
                        table.Columns.Add("Nome", typeof(string));
                        table.Columns.Add("CPFCNPJ", typeof(string));
                        table.Columns.Add("Status", typeof(string));
                        table.Columns.Add("Mensagem", typeof(string));
                        table.Columns.Add("MotivoReprovacao", typeof(string));
                        table.Columns.Add("URLTrust", typeof(string));
                        table.Columns.Add("IdArquivo", typeof(int));
                        table.Columns.Add("ind_positivo", typeof(bool));

                        foreach (var registro in buffer)
                        {
                            table.Rows.Add(
                                registro.ID,
                                registro.CriadoEm ?? (object)DBNull.Value,
                                registro.AtualizadoEm ?? (object)DBNull.Value,
                                registro.CriadoPor,
                                registro.Nome,
                                registro.CPFCNPJ,
                                registro.Status,
                                registro.Mensagem,
                                registro.MotivoReprovacao,
                                registro.URLTrust,
                                registro.IdArquivo,
                                registro.ind_positivo
                            );
                        }

                        using (var writer = connection.BeginBinaryImport("COPY Acam_Restritiva (ID, CriadoEm, AtualizadoEm, CriadoPor, Nome, CPFCNPJ, Status, Mensagem, MotivoReprovacao, URLTrust, IdArquivo, ind_positivo) FROM STDIN (FORMAT BINARY)"))
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                writer.StartRow();
                                for (int i = 0; i < table.Columns.Count; i++)
                                {
                                    writer.Write(row[i]);
                                }
                            }
                            writer.Complete();
                        }

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = new LoggerRepository();
                logger.Log(ex);
            }
        }
        public void SalvarNaTabelaRestritiva(decimal valorMaximo, int idFile)
        {
            string queryTruncar = "TRUNCATE TABLE Acam_Restritiva";

            string queryFiltrar = @"
                SELECT 
                    SUM(Amount) AS TotalAmount,
                    Client,
                    Pix_Key,
                    cpf_name,
                    CURRENT_DATE AS TrnDate
                FROM AcamData
                WHERE TrnDate >= CURRENT_DATE - INTERVAL '365 days'
                GROUP BY 
                    Client,
                    Pix_Key,
                    cpf_name
                HAVING SUM(Amount) > @valorMaximo";

            string queryInserir = @"
                        INSERT INTO Acam_Restritiva (Client, Pix_Key, cpf_name, Amount, TrnDate, Id_arquivo)
                        VALUES (@Client, @Pix_Key, @cpf_name, @Amount, @TrnDate, @Id_arquivo)";

            var registrosFiltrados = new List<AcamDTO>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Truncate table
                        using (var truncCommand = new NpgsqlCommand(queryTruncar, connection, transaction))
                        {
                            truncCommand.ExecuteNonQuery();
                        }

                        // Filtrar registros
                        using (var command = new NpgsqlCommand(queryFiltrar, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@valorMaximo", valorMaximo);

                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var registro = new AcamDTO
                                    {
                                        Client = reader["Client"].ToString(),
                                        Pix_Key = reader["Pix_Key"].ToString(),
                                        cpf_name = reader["cpf_name"].ToString(),
                                        Amount = reader["TotalAmount"].ToString(),
                                        TrnDate = reader["TrnDate"] as DateTime?
                                    };

                                    registrosFiltrados.Add(registro);
                                }
                            }
                        }

                        // Inserir os registros na tabela restritiva
                        foreach (var registro in registrosFiltrados)
                        {
                            using (var insertCommand = new NpgsqlCommand(queryInserir, connection, transaction))
                            {
                                insertCommand.Parameters.AddWithValue("@Client", registro.Client);
                                insertCommand.Parameters.AddWithValue("@Pix_Key", registro.Pix_Key);
                                insertCommand.Parameters.AddWithValue("@cpf_name", registro.cpf_name);

                                // Converter Amount para decimal ou passar DBNull se inválido
                                if (decimal.TryParse(registro.Amount, NumberStyles.Any, new CultureInfo("pt-BR"), out var amount))
                                {
                                    insertCommand.Parameters.AddWithValue("@Amount", amount);
                                }
                                else
                                {
                                    insertCommand.Parameters.AddWithValue("@Amount", DBNull.Value);
                                }

                                insertCommand.Parameters.AddWithValue("@TrnDate", registro.TrnDate ?? (object)DBNull.Value);
                                insertCommand.Parameters.AddWithValue("@Id_arquivo", idFile);

                                insertCommand.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Erro ao inserir na tabela Acam_Restritiva: {ex.Message}");
                    }
                }
            }
        }

        public void GerarRelatorioSaidaProcessamento(int idFile)
        {
            try
            {
                _NOME_RELATORIO = NomeDoRelatorio();

                string queryFiltrar = @"
                SELECT 
                    a.Amount,
                    a.Client,
                    a.Pix_key,
                    a.cpf_name,
	                a.TrnDate,
	                case 
	                  when ar.Pix_key is null then 0 
	                  else 1 
	                 end as Restrito
                FROM AcamData a left join Acam_Restritiva ar on ar.Client = a.Client and ar.Pix_key = a.Pix_key
                WHERE 
                  a.Id_arquivo = @idFile";

                var arquivosProcessados = new List<string>();

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    var registrosFiltrados = new List<AcamDTO>();
                    var registrosNaoInseridos = new List<AcamDTO>();

                    using (var command = new NpgsqlCommand(queryFiltrar, connection))
                    {
                        command.Parameters.AddWithValue("@idFile", idFile);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var registro = new AcamDTO
                                {
                                    Client = reader["Client"].ToString(),
                                    Pix_Key = reader["Pix_Key"].ToString(),
                                    cpf_name = reader["cpf_name"].ToString(),
                                    Amount = reader["Amount"].ToString(),
                                    TrnDate = reader["TrnDate"] as DateTime?,
                                    restrito = int.Parse(reader["Restrito"].ToString())
                                };

                                registrosFiltrados.Add(registro);
                            }
                        }
                    }

                    if (registrosFiltrados.Count > 0)
                    {
                        var registroForaLimite = registrosFiltrados.Where(x => x.restrito == 1).ToList();
                        var registroDentroLimite = registrosFiltrados.Where(x => x.restrito == 0).ToList();

                        // Aqui precisa gerar a planiha com as duas abas 
                        if (registroForaLimite.Count > 0 || registroDentroLimite.Count > 0)
                        {
                            //GERAR ACAM DE SAIDA
                            GerarAcamSaida(registroForaLimite, registroDentroLimite);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = new LoggerRepository();
                logger.Log(ex);
            }
        }
        public IEnumerable<AcamDTO> ConsultaBaseRestritra(string dataInicial, string dataFinal, string documento)
        {


            try
            {
                string queryFiltrar = @"
                SELECT 
                    ar.Amount,
                    ar.Client,
                    ar.Pix_key,
                    ar.cpf_name,
	                ar.TrnDate,
	                case 
	                  when ar.Pix_key is null then 0 
	                  else 1 
	                 end as Restrito
                FROM  Acam_Restritiva ar 
                WHERE 
	                case 
	                  when ar.Pix_key is null then 0 
	                  else 1 
	                 end = 1 
                ";

                if (dataInicial != "" && dataFinal != "")
                {
                    queryFiltrar = queryFiltrar + " and ar.TrnDate between '" + dataInicial + "' and '" + dataFinal + "' ";
                }
                if (documento != "")
                {
                    queryFiltrar = queryFiltrar + " and replace(replace(replace(replace(ar.Pix_key,'.',''),',',''),'-',''),'/','') = '" + documento + "' ";
                }

                var registrosFiltrados = new List<AcamDTO>();

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(queryFiltrar, connection))
                    {
                        //command.Parameters.AddWithValue("@dataIni", dataInicial);
                        //command.Parameters.AddWithValue("@dataFim", dataFinal);
                        //command.Parameters.AddWithValue("@doc", documento);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var registro = new AcamDTO
                                {
                                    Client = reader["Client"].ToString(),
                                    Pix_Key = reader["Pix_Key"].ToString(),
                                    cpf_name = reader["cpf_name"].ToString(),
                                    Amount = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "R$ {0:#,###.##}", reader["Amount"]),
                                    TrnDate = reader["TrnDate"] as DateTime?,
                                    restrito = int.Parse(reader["Restrito"].ToString())
                                };

                                registrosFiltrados.Add(registro);
                            }
                        }
                    }
                }

                return registrosFiltrados;
            }
            catch (Exception ex)
            {
                var logger = new LoggerRepository();
                logger.Log(ex);
                return new List<AcamDTO>();
            }

        }

        public void GerarRelatorio(int idArquivo, string caminhoArquivo)
        {
            try
            {
                _NOME_RELATORIO = NomeDoRelatorio();

                string queryFiltrar = @"
                SELECT 
                    a.Amount,
                    a.Client,
                    a.Pix_key,
                    a.cpf_name,
	                a.TrnDate,
	                case 
	                  when ar.Pix_key is null then 0 
	                  else 1 
	                 end as Restrito
                FROM AcamData a left join Acam_Restritiva ar on ar.Client = a.Client and ar.Pix_key = a.Pix_key
                WHERE 
                  a.Id_arquivo = @idFile";

                var arquivosProcessados = new List<string>();

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    var registrosFiltrados = new List<AcamDTO>();
                    var registrosNaoInseridos = new List<AcamDTO>();

                    using (var command = new NpgsqlCommand(queryFiltrar, connection))
                    {
                        command.Parameters.AddWithValue("@idFile", idArquivo);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var registro = new AcamDTO
                                {
                                    Client = reader["Client"].ToString(),
                                    Pix_Key = reader["Pix_Key"].ToString(),
                                    cpf_name = reader["cpf_name"].ToString(),
                                    Amount = reader["Amount"].ToString(),
                                    TrnDate = reader["TrnDate"] as DateTime?,
                                    restrito = int.Parse(reader["Restrito"].ToString())
                                };

                                registrosFiltrados.Add(registro);
                            }
                        }
                    }

                    if (registrosFiltrados.Count > 0)
                    {
                        var registroForaLimite = registrosFiltrados.Where(x => x.restrito == 1).ToList();
                        var registroDentroLimite = registrosFiltrados.Where(x => x.restrito == 0).ToList();

                        // Aqui precisa gerar a planiha com as duas abas 
                        if (registroForaLimite.Count > 0 || registroDentroLimite.Count > 0)
                        {
                            //GERAR ACAM DE SAIDA
                            GerarRelatorioFinal(registroForaLimite, registroDentroLimite,caminhoArquivo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = new LoggerRepository();
                logger.Log(ex);
            }
        }

        //Validar se ainda usa
        public IEnumerable<AcamDTO> FiltrarRegistrosPorValor(decimal valorMinimo, int idFile)
        {
            try
            {
                string query = @"
                    SELECT Client, Pix_Key, cpf_name, Amount, TrnDate
                    FROM AcamData
                    WHERE Amount >= @valorMinimo
                      AND Id_file = @idFile
                      AND TrnDate >= CURRENT_DATE - INTERVAL '365 days'";

                var registros = new List<AcamDTO>();

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@valorMinimo", valorMinimo);
                        command.Parameters.AddWithValue("@idFile", idFile);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                registros.Add(new AcamDTO
                                {
                                    Client = reader["Client"].ToString(),
                                    Pix_Key = reader["Pix_Key"].ToString(),
                                    cpf_name = reader["cpf_name"].ToString(),
                                    Amount = reader["Amount"].ToString(),
                                    TrnDate = reader["TrnDate"] as DateTime?
                                });
                            }
                        }
                    }
                }

                return registros;
            }
            catch (Exception ex)
            {
                var logger = new LoggerRepository();
                logger.Log(ex);
                return new List<AcamDTO>();
            }
        }

        public void InserirNaTabelaRestritiva(decimal valorMinimo, int idFile)
        {
            _NOME_RELATORIO = NomeDoRelatorio();

            string queryFiltrar = @"
                SELECT Client, Pix_Key, cpf_name, Amount, TrnDate
                FROM AcamData
                WHERE Amount > @valorMinimo
                  AND Id_arquivo = @idFile
                  AND TrnDate >= DATEADD(DAY, -365, GETDATE())";
            
            string queryFiltrarTudo = @"
                SELECT Client, Pix_Key, cpf_name, Amount, TrnDate
                FROM AcamData
                WHERE Id_arquivo = @idFile";

            string queryTrucar = "TRUNCATE TABLE Acam_Restritiva";

            string queryInserir = @"
                INSERT INTO Acam_Restritiva (Client, Pix_Key, cpf_name, Amount, TrnDate, Id_arquivo)
                VALUES (@Client, @Pix_Key, @cpf_name, @Amount, @TrnDate, @Id_arquivo)";

            var arquivosProcessados = new List<string>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {

                        using (var truncCommand = new NpgsqlCommand(queryTrucar, connection, transaction))
                        {
                            truncCommand.ExecuteNonQuery();
                        }
                        var registrosFiltrados = new List<AcamDTO>();
                        var registrosNaoInseridos = new List<AcamDTO>();

                        using (var command = new NpgsqlCommand(queryFiltrar, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@valorMinimo", valorMinimo);
                            command.Parameters.AddWithValue("@idFile", idFile);

                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var registro = new AcamDTO
                                    {
                                        Client = reader["Client"].ToString(),
                                        Pix_Key = reader["Pix_Key"].ToString(),
                                        cpf_name = reader["cpf_name"].ToString(),
                                        Amount = reader["Amount"].ToString(),
                                        TrnDate = reader["TrnDate"] as DateTime?
                                    };

                                    if (decimal.TryParse(registro.Amount, NumberStyles.Any, new CultureInfo("pt-BR"), out var amount) && amount > valorMinimo)
                                    {
                                        registrosFiltrados.Add(registro);
                                    }
                                    else
                                    {
                                        registrosNaoInseridos.Add(registro);
                                    }
                                }
                            }
                        }

                        if(registrosNaoInseridos.Count == 0)
                        {
                            using (var command = new NpgsqlCommand(queryFiltrarTudo, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@idFile", idFile);

                                using (var reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        var registro = new AcamDTO
                                        {
                                            Client = reader["Client"].ToString(),
                                            Pix_Key = reader["Pix_Key"].ToString(),
                                            cpf_name = reader["cpf_name"].ToString(),
                                            Amount = reader["Amount"].ToString(),
                                            TrnDate = reader["TrnDate"] as DateTime?
                                        };

                                        registrosNaoInseridos.Add(registro);
                                    }
                                }
                            }
                        }

                        // Inserir os registros na tabela restritiva
                        foreach (var registro in registrosFiltrados)
                        {
                            using (var insertCommand = new NpgsqlCommand(queryInserir, connection, transaction))
                            {
                                insertCommand.Parameters.AddWithValue("@Client", registro.Client);
                                insertCommand.Parameters.AddWithValue("@Pix_Key", registro.Pix_Key);
                                insertCommand.Parameters.AddWithValue("@cpf_name", registro.cpf_name);

                                // Converter o Amount para decimal ou passar DBNull se inválido
                                if (decimal.TryParse(registro.Amount, NumberStyles.Any, new CultureInfo("pt-BR"), out var amount))
                                {
                                    insertCommand.Parameters.AddWithValue("@Amount", amount);
                                }
                                else
                                {
                                    insertCommand.Parameters.AddWithValue("@Amount", DBNull.Value);
                                }

                                insertCommand.Parameters.AddWithValue("@TrnDate", registro.TrnDate ?? (object)DBNull.Value);
                                insertCommand.Parameters.AddWithValue("@Id_arquivo", idFile);

                                insertCommand.ExecuteNonQuery();
                            }
                        }


                        transaction.Commit();
                        // Gerar relatório dos não inseridos
                        if(registrosNaoInseridos.Count > 0)
                        {
                            SalvarRelatorioNaoInseridos(registrosNaoInseridos, idFile);
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Erro ao inserir na tabela Acam_Restritiva: {ex.Message}");
                    }
                }
            }
        }
        public string NomeDoRelatorio()
        {
            string inicio = "RelatorioNaoInseridos";
            string data = $"_{ DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}";
            string hora = $"_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}";

            return inicio + data+ hora+ ".xlsx";
        }
        private void GerarAcamSaida(IEnumerable<AcamDTO> registroForaLimite, IEnumerable<AcamDTO> registroDentroLimite)
        {
            try
            {
                string caminhoImportacao = _caminhoImportacaoLocal;
                string pastaRelatorios = Path.Combine(caminhoImportacao, "processados", "relatorios");

                if (!Directory.Exists(pastaRelatorios))
                {
                    Directory.CreateDirectory(pastaRelatorios);
                }

                string caminhoRelatorio = Path.Combine(pastaRelatorios, NomeDoRelatorio());

                using var workbook = new XLWorkbook();

                var worksheetBanco = workbook.Worksheets.Add("Registros dentro do limite");
                PreencherGuiaExcel(worksheetBanco, registroDentroLimite);

                var worksheetNaoInseridos = workbook.Worksheets.Add("Registros fora do limite");
                PreencherGuiaExcel(worksheetNaoInseridos, registroForaLimite);

                workbook.SaveAs(caminhoRelatorio);
                Console.WriteLine($"Relatório salvo em: {pastaRelatorios}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void GerarRelatorioFinal(IEnumerable<AcamDTO> registroForaLimite, IEnumerable<AcamDTO> registroDentroLimite,string caminho)
        {
            try
            {
                string caminhoImportacao = _caminhoImportacaoLocal;
                string pastaRelatorios = Path.Combine(caminhoImportacao, caminho, "processados", "relatorios");

                if (!Directory.Exists(pastaRelatorios))
                {
                    Directory.CreateDirectory(pastaRelatorios);
                }

                string caminhoRelatorio = Path.Combine(pastaRelatorios, NomeDoRelatorio());

                using var workbook = new XLWorkbook();

                var worksheetBanco = workbook.Worksheets.Add("Registros dentro do limite");
                PreencherGuiaExcel(worksheetBanco, registroDentroLimite);

                var worksheetNaoInseridos = workbook.Worksheets.Add("Registros fora do limite");
                PreencherGuiaExcel(worksheetNaoInseridos, registroForaLimite);

                workbook.SaveAs(caminhoRelatorio);
                Console.WriteLine($"Relatório salvo em: {pastaRelatorios}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void SalvarRelatorioNaoInseridos(IEnumerable<AcamDTO> registros, int idArquivo)
        {
            try
            {
                string pastaRelatorios = Path.Combine(_caminhoImportacaoLocal, "processados", "relatorios");

                if (!Directory.Exists(pastaRelatorios))
                {
                    Directory.CreateDirectory(pastaRelatorios);
                }

                string caminhoRelatorio = Path.Combine(pastaRelatorios, NomeDoRelatorio());

                using var workbook = new XLWorkbook();

                var worksheetBanco = workbook.Worksheets.Add("Registros Banco");
                var registrosBanco = ObterRegistrosBanco(idArquivo); 
                PreencherGuiaExcel(worksheetBanco, registrosBanco);

                var worksheetNaoInseridos = workbook.Worksheets.Add("Não Inseridos");
                PreencherGuiaExcel(worksheetNaoInseridos, registros);

                workbook.SaveAs(caminhoRelatorio);
                Console.WriteLine($"Relatório salvo em: {pastaRelatorios}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DataTable GerarRelatorioVisualTotal(int idFile)
        {
            try
            {
                DataTable dataTable = new DataTable();

                string query = @"
                                SELECT 
                                    Client, 
                                    Pix_Key, 
                                    cpf_name, 
                                    Amount, 
                                    TrnDate,
                                    Id_arquivo
                                FROM AcamData
                                WHERE id_arquivo = @Id_arquivo";

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id_arquivo", idFile);

                        using (var reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader); 
                        }
                    }
                }

                return dataTable; 
            }
            catch (Exception ex)
            {
                var logger = new LoggerRepository();
                logger.Log(ex);

                return new DataTable();
            }
        }
        private IEnumerable<AcamDTO> ObterRegistrosBanco(int idArquivo)
        {
            var registros = new List<AcamDTO>();
            string query = @"
                                SELECT Client, Pix_Key, cpf_name, Amount, TrnDate
                                FROM AcamData
                                WHERE id_arquivo = @Id_arquivo";

            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id_arquivo", idArquivo);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                registros.Add(new AcamDTO
                                {
                                    Client = reader["Client"].ToString(),
                                    Pix_Key = reader["Pix_Key"].ToString(),
                                    cpf_name = reader["cpf_name"].ToString(),
                                    Amount = reader["Amount"].ToString(),
                                    TrnDate = reader["TrnDate"] as DateTime?
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao recuperar registros do banco: {ex.Message}");
            }

            return registros;
        }
        private void PreencherGuiaExcel(IXLWorksheet worksheet, IEnumerable<AcamDTO> registros)
        {
            // Cabeçalhos
            worksheet.Cell(1, 1).Value = "Client";
            worksheet.Cell(1, 2).Value = "Pix_Key";
            worksheet.Cell(1, 3).Value = "cpf_name";
            worksheet.Cell(1, 4).Value = "Amount";
            worksheet.Cell(1, 5).Value = "TrnDate";

            // Dados
            var linha = 2;
            foreach (var registro in registros)
            {
                worksheet.Cell(linha, 1).Value = registro.Client;
                worksheet.Cell(linha, 2).Value = registro.Pix_Key;
                worksheet.Cell(linha, 3).Value = registro.cpf_name;
                worksheet.Cell(linha, 4).Value = registro.Amount;
                worksheet.Cell(linha, 5).Value = registro.TrnDate;
                linha++;
            }

            // Ajuste automático de colunas
            worksheet.Columns().AdjustToContents();
        }

        public DataTable GerarRelatorioVisualNaoProcessados(int idFile)
        {
            try
            {
                DataTable dataTable = new DataTable();

                string query = @"
                                SELECT 
                                    Client, 
                                    Pix_Key, 
                                    cpf_name, 
                                    Amount, 
                                    TrnDate,
                                    Id_arquivo
                                FROM Acam_Restritiva
                                WHERE id_arquivo = @Id_arquivo";

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id_arquivo", idFile);

                        using (var reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                var logger = new LoggerRepository();
                logger.Log(ex);

                return new DataTable();
            }
        }
        public DataTable ListarArquivosJaProcessadosDoBanco()
        {
            DataTable dataTable = new DataTable();

            string query = @"SELECT
                                Id_arquivo,
                                Nome_arquivo
                            FROM AcamArquivo";


            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            return dataTable;

        }
        public IEnumerable<AcamDTO> ConsultaBaseGeral(string dataInicial, string dataFinal, int documento)
        {
            try
            {
                string queryFiltrar = @"
                SELECT 
                    Amount,
                    Client,
                    Pix_key,
                    cpf_name,
	                TrnDate,
	                case 
	                  when Pix_key is null then 0 
	                  else 1 
	                 end as Restrito,
                    Id_arquivo
                FROM  AcamData 
                ";

                if (dataInicial != "" && dataFinal != "")
                {
                    if (!queryFiltrar.ToLower().Contains("where"))
                        queryFiltrar += " where TrnDate between '" + dataInicial + "' and '" + dataFinal + "' ";
                    else
                        queryFiltrar += " and TrnDate between '" + dataInicial + "' and '" + dataFinal + "' ";
                }

                if (!queryFiltrar.ToLower().Contains("where"))
                    queryFiltrar += $" where id_arquivo = {documento}";
                else
                    queryFiltrar += $" and id_arquivo = {documento}";

                var registrosFiltrados = new List<AcamDTO>();

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(queryFiltrar, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var registro = new AcamDTO
                                {
                                    Client = reader["Client"].ToString(),
                                    Pix_Key = reader["Pix_Key"].ToString(),
                                    cpf_name = reader["cpf_name"].ToString(),
                                    Amount = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "R$ {0:#,###.##}", reader["Amount"]),
                                    Id_file = int.Parse(reader["Id_arquivo"].ToString()),
                                    TrnDate = reader["TrnDate"] as DateTime?,
                                    restrito = int.Parse(reader["Restrito"].ToString())
                                };

                                registrosFiltrados.Add(registro);
                            }
                        }
                    }
                }
                return registrosFiltrados;
            }
            catch (Exception ex)
            {
                var logger = new LoggerRepository();
                logger.Log(ex);

                return new List<AcamDTO>();
            }

            
        }
        public void ForcaImportacaoRestritiva(int idArquivo) 
        {  
            string queryInserir = @"
                        INSERT INTO Acam_Restritiva (Client, Pix_Key, cpf_name, Amount, TrnDate, Id_arquivo)
                        VALUES (@Client, @Pix_Key, @cpf_name, @Amount, @TrnDate, @Id_arquivo)";

            var registrosFiltrados = new List<AcamDTO>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Inserir os registros na tabela restritiva
                        foreach (var registro in registrosFiltrados)
                        {
                            using (var insertCommand = new NpgsqlCommand(queryInserir, connection, transaction))
                            {
                                insertCommand.Parameters.AddWithValue("@Client", registro.Client);
                                insertCommand.Parameters.AddWithValue("@Pix_Key", registro.Pix_Key);
                                insertCommand.Parameters.AddWithValue("@cpf_name", registro.cpf_name);

                                // Converter Amount para decimal ou passar DBNull se inválido
                                if (decimal.TryParse(registro.Amount, NumberStyles.Any, new CultureInfo("pt-BR"), out var amount))
                                {
                                    insertCommand.Parameters.AddWithValue("@Amount", amount);
                                }
                                else
                                {
                                    insertCommand.Parameters.AddWithValue("@Amount", DBNull.Value);
                                }

                                insertCommand.Parameters.AddWithValue("@TrnDate", registro.TrnDate ?? (object)DBNull.Value);
                                insertCommand.Parameters.AddWithValue("@Id_arquivo", idArquivo);

                                insertCommand.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Erro ao inserir na tabela Acam_Restritiva: {ex.Message}");
                    }
                }
            }
        }
        public async Task ImportarCAF(List<AcamRestritivaCAFDTO> buffer)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        var table = new DataTable();
                        table.Columns.Add("ID", typeof(string));
                        table.Columns.Add("CriadoEm", typeof(DateTime));
                        table.Columns.Add("AtualizadoEm", typeof(DateTime));
                        table.Columns.Add("CriadoPor", typeof(string));
                        table.Columns.Add("Nome", typeof(string));
                        table.Columns.Add("CPFCNPJ", typeof(string));
                        table.Columns.Add("Status", typeof(string));
                        table.Columns.Add("Mensagem", typeof(string));
                        table.Columns.Add("MotivoReprovacao", typeof(string));
                        table.Columns.Add("URLTrust", typeof(string));
                        table.Columns.Add("IdArquivo", typeof(int));

                        foreach (var registro in buffer)
                        {
                            table.Rows.Add(
                                registro.ID,
                                registro.CriadoEm ?? (object)DBNull.Value,
                                registro.AtualizadoEm ?? (object)DBNull.Value,
                                registro.CriadoPor,
                                registro.Nome,
                                registro.CPFCNPJ,
                                registro.Status,
                                registro.Mensagem,
                                registro.MotivoReprovacao,
                                registro.URLTrust,
                                registro.IdArquivo
                            );
                        }

                        using (var writer = connection.BeginBinaryImport("COPY CAF (ID, CriadoEm, AtualizadoEm, CriadoPor, Nome, CPFCNPJ, Status, Mensagem, MotivoReprovacao, URLTrust, Id_arquivo) FROM STDIN (FORMAT BINARY)"))
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                writer.StartRow();
                                for (int i = 0; i < table.Columns.Count; i++)
                                {
                                    writer.Write(row[i]);
                                }
                            }
                            writer.Complete();
                        }

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = new LoggerRepository();
                logger.Log(ex);
            }
        }

        public void ProcessaCAFCSV(int idArquivo, string caminho)
        {
            using (var reader = new StreamReader(caminho))
            {
                var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    MissingFieldFound = null // Ignorar campos ausentes
                };

                using (var csv = new CsvReader(reader, config))
                {
                    csv.Read(); // Ignorar cabeçalho
                    csv.ReadHeader();

                    var buffer = new List<AcamRestritivaCAFDTO>();
                    while (csv.Read())
                    {
                        try
                        {
                            var registro = csv.GetRecord<AcamRestritivaCAFDTO>();
                            registro.IdArquivo = idArquivo; 
                            buffer.Add(registro);

                            if (buffer.Count == 1000)
                            {
                                ImportarCAF(buffer); // Salvar no banco em lotes
                                buffer.Clear();
                            }
                        }
                        catch (CsvHelperException ex)
                        {
                            Console.WriteLine($"Erro ao processar o registro: {ex.Message}");
                        }
                    }

                    if (buffer.Count > 0)
                    {
                        ImportarCAF(buffer); // Salvar qualquer dado restante
                    }
                }
            }
        }
    }

}
