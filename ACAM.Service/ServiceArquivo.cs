using ACAM.Data;
using ACAM.Domain.Interface.Repository;
using ACAM.Domain.Interface.Service;
using Microsoft.Data.SqlClient;
using Npgsql;
using System.IO.Compression;

namespace ACAM.Service
{
    public class ServiceArquivo : IServiceArquivo
    {
        public IRepositoryArquivo _repository = new RepositoryArquivo();

        public async Task<int> InicioDoProcessoArquivo(string localDoArquivo)
        {
            return await _repository.InicioDoProcessoArquivo(localDoArquivo);
        }

        public async Task InserirArquivo(string nomeArquivo, NpgsqlConnection connection, NpgsqlTransaction transaction)
        {
            await _repository.InserirArquivo(nomeArquivo,connection, transaction);
        }

        public async Task<int> RecuperarIdArquivo(string nomeArquivo, NpgsqlConnection connection, NpgsqlTransaction transaction)
        {
            return await _repository.RecuperarIdArquivo(nomeArquivo, connection, transaction);
        }
    }
}
