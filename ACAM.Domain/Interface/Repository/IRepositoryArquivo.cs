using Microsoft.Data.SqlClient;
using Npgsql;

namespace ACAM.Domain.Interface.Repository
{
    public interface IRepositoryArquivo
    {
        Task<int> InicioDoProcessoArquivo(string localDoArquivo);

        Task InserirArquivo(string nomeArquivo, NpgsqlConnection connection, NpgsqlTransaction transaction);

        Task<int> RecuperarIdArquivo(string nomeArquivo, NpgsqlConnection connection, NpgsqlTransaction transaction);
    }
}
