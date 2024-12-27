using Microsoft.Data.SqlClient;
using Npgsql;

namespace ACAM.Domain.Interface.Service
{
    public interface IServiceArquivo
    {
        Task<int> InicioDoProcessoArquivo(string localDoArquivo);

        Task InserirArquivo(string nomeArquivo, NpgsqlConnection connection, NpgsqlTransaction transaction);

        Task<int> RecuperarIdArquivo(string nomeArquivo, NpgsqlConnection connection, NpgsqlTransaction transaction);
    }
}
