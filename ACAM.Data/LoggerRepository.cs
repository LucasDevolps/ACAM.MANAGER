using ACAM.Domain.Interface.Repository;
using Microsoft.Data.SqlClient;
using System;

namespace ACAM.Data
{
    public class LoggerRepository : ILogger
    {
        private readonly string _connectionString = "Server=localhost;Database=ACAM;Trusted_Connection=True;TrustServerCertificate=True;";

        public void Log(Exception exception)
        {
            string query = @"
                INSERT INTO LOGGER (mensagem, stack)
                VALUES (@Mensagem, @Stack)";

            try
            {
                // Estabelece conexão com o banco de dados
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Executa o comando
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Mensagem", exception.Message);
                        command.Parameters.AddWithValue("@Stack", exception.StackTrace ?? string.Empty); // Evita valor nulo para StackTrace
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Aqui você pode decidir como tratar erros ao salvar logs
                Console.WriteLine($"Erro ao gravar log: {ex.Message}");
            }
        }
    }
}
