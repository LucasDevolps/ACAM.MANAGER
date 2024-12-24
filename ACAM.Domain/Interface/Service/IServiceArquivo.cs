using Microsoft.Data.SqlClient;

namespace ACAM.Domain.Interface.Service
{
    public interface IServiceArquivo
    {
        Task<int> InicioDoProcessoArquivo(string connectionString, string localDoArquivo);

        Task InserirArquivo(string nomeArquivo, SqlConnection connection, SqlTransaction transaction);

        Task<int> RecuperarIdArquivo(string nomeArquivo, SqlConnection connection, SqlTransaction transaction);
    }
}
