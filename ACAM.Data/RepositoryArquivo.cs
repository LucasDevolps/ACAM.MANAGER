using Microsoft.Data.SqlClient;
using ACAM.Domain.Interface.Repository;


namespace ACAM.Data
{
    public class RepositoryArquivo : IRepositoryArquivo
    {
        public async Task<int> InicioDoProcessoArquivo(string connectionString, string localDoArquivo)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string nomeArquivo = Path.GetFileName(localDoArquivo);

                        await InserirArquivo(nomeArquivo, connection, transaction);

                        return await RecuperarIdArquivo(nomeArquivo, connection, transaction);

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        var logger = new LoggerRepository();
                        logger.Log(ex);
                        return 0;
                    }
                }
            }
        }
        public async Task InserirArquivo(string nomeArquivo, SqlConnection connection, SqlTransaction transaction)
        {
            try
            {
                string query = @"
                INSERT INTO AcamArquivo (Nome_arquivo)
                VALUES (@Nome_arquivo)";

                using (var command = new SqlCommand(query, connection, transaction))
                {
                    command.Parameters.AddWithValue("@Nome_arquivo", nomeArquivo);
                    await command.ExecuteScalarAsync();
                }

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                var logger = new LoggerRepository();
                logger.Log(ex);
            }
        }

        public async Task<int> RecuperarIdArquivo(string nomeArquivo, SqlConnection connection, SqlTransaction transaction)
        {
            try
            {
                string query = @"
                    SELECT Id_arquivo
                    FROM AcamArquivo
                    WHERE Nome_arquivo = @Nome_arquivo
                      AND CAST(Data_importacao AS DATE) = CAST(GETDATE() AS DATE)";

                using (var command = new SqlCommand(query, connection, transaction))
                {
                    command.Parameters.AddWithValue("@Nome_arquivo", nomeArquivo);

                    var result = await command.ExecuteScalarAsync();
                    if (result != null && int.TryParse(result.ToString(), out int idArquivo))
                    {
                        return idArquivo;
                    }
                    else
                    {
                        throw new InvalidOperationException("Não foi possível recuperar o Id_arquivo para o arquivo inserido.");
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
