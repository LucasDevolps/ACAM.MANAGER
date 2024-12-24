using ACAM.Data;
using ACAM.Domain.Interface.Repository;
using ACAM.Domain.Interface.Service;
using Microsoft.Data.SqlClient;
using System.IO.Compression;

namespace ACAM.Service
{
    public class ServiceArquivo : IServiceArquivo
    {
        public IRepositoryArquivo _repository = new RepositoryArquivo();

        public async Task<int> InicioDoProcessoArquivo(string connectionString, string localDoArquivo)
        {
            return await _repository.InicioDoProcessoArquivo(connectionString, localDoArquivo);
        }

        public async Task InserirArquivo(string nomeArquivo, SqlConnection connection, SqlTransaction transaction)
        {
            await _repository.InserirArquivo(nomeArquivo,connection, transaction);
        }

        public async Task<int> RecuperarIdArquivo(string nomeArquivo, SqlConnection connection, SqlTransaction transaction)
        {
            return await _repository.RecuperarIdArquivo(nomeArquivo, connection, transaction);
        }
    }
}
