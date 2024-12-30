using Microsoft.Data.SqlClient;
using Npgsql;

namespace ACAM.Domain.Interface.Repository
{
    public interface IRepositoryArquivo
    {
        Task<int> InicioDoProcessoArquivo(string localDoArquivo);

        Task InserirArquivo(string nomeArquivo, SqlConnection connection, SqlTransaction transaction);

        Task<int> RecuperarIdArquivo(string nomeArquivo, SqlConnection connection, SqlTransaction transaction);
    }
}
