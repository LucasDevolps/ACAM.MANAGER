using ACAM.Domain.Interface.Repository;
using Microsoft.Extensions.Configuration;
using Npgsql; // Biblioteca para PostgreSQL
using System;

namespace ACAM.Data
{
    public class LoggerRepository : ILogger
    {
        private string _connectionString = string.Empty;

        private ConfigurationBuilder builder = new ConfigurationBuilder();

        private IConfiguration configuration;

        public void Log(Exception exception)
        {
            builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";

            string query = @"
                INSERT INTO logger (mensagem, stack)
                VALUES (@Mensagem, @Stack)";

            try
            {
                // Estabelece conexão com o banco de dados
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    // Executa o comando
                    using (var command = new NpgsqlCommand(query, connection))
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
