using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql; // Biblioteca para PostgreSQL
using ACAM.Domain.Interface.Repository;

namespace ACAM.Data
{
    public class RepositoryArquivo : IRepositoryArquivo
    {
        private string _connectionString = string.Empty;

        public RepositoryArquivo()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = builder.Build();
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        public async Task<int> InicioDoProcessoArquivo(string localDoArquivo)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = await connection.BeginTransactionAsync())
                {
                    try
                    {
                        string nomeArquivo = Path.GetFileName(localDoArquivo);

                        await InserirArquivo(nomeArquivo, connection, transaction);

                        return await RecuperarIdArquivo(nomeArquivo, connection, transaction);
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        var logger = new LoggerRepository();
                        logger.Log(ex);
                        return 0;
                    }
                }
            }
        }

        public async Task InserirArquivo(string nomeArquivo, NpgsqlConnection connection, NpgsqlTransaction transaction)
        {
            try
            {
                string query = @"
                    INSERT INTO AcamArquivo (nome_arquivo)
                    VALUES (@Nome_arquivo)";

                using (var command = new NpgsqlCommand(query, connection, transaction))
                {
                    command.Parameters.AddWithValue("@Nome_arquivo", nomeArquivo);
                    await command.ExecuteNonQueryAsync();
                }

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                var logger = new LoggerRepository();
                logger.Log(ex);
                throw; // Re-throw para propagar a exceção
            }
        }

        public async Task<int> RecuperarIdArquivo(string nomeArquivo, NpgsqlConnection connection, NpgsqlTransaction transaction)
        {
            try
            {
                string query = @"
                    SELECT id_arquivo
                    FROM AcamArquivo
                    WHERE nome_arquivo = @Nome_arquivo
                      AND CAST(data_importacao AS DATE) = CURRENT_DATE";

                using (var command = new NpgsqlCommand(query, connection, transaction))
                {
                    command.Parameters.AddWithValue("@Nome_arquivo", nomeArquivo);

                    var result = await command.ExecuteScalarAsync();
                    if (result != null && int.TryParse(result.ToString(), out int idArquivo))
                    {
                        return idArquivo;
                    }
                    else
                    {
                        throw new InvalidOperationException("Não foi possível recuperar o id_arquivo para o arquivo inserido.");
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = new LoggerRepository();
                logger.Log(ex);
                return 0;
            }
        }
    }
}
