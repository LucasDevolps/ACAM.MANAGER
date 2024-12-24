using Microsoft.Data.SqlClient;

namespace ACAM.Domain.Interface.Repository
{
    public interface IRepositoryArquivo
    {
        Task<int> InicioDoProcessoArquivo(string connectionString, string localDoArquivo);

        Task InserirArquivo(string nomeArquivo, SqlConnection connection, SqlTransaction transaction);

        Task<int> RecuperarIdArquivo(string nomeArquivo, SqlConnection connection, SqlTransaction transaction);
    }
}
