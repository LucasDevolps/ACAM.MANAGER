using ACAM.Data;
using ACAM.Domain.DTOs;
using ACAM.Domain.Interface.Repository;
using ACAM.Domain.Interface.Service;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ACAM.Service
{
    public class ServicesRegistros : IServicesRegistros
    {

        private ConfigurationBuilder builder = new ConfigurationBuilder();

        private IRepositoryRegistros _repository = new RepositoryRegistros();


        public void ProcessarCsvPorStreaming(string caminhoCsv, int idArquivo)
        {
            _repository.ProcessarCsvPorStreaming(caminhoCsv, idArquivo);
        }
        public void SalvarNoBanco(List<AcamDTO> buffer, int idArquivo)
        {
            _repository.SalvarNoBanco(buffer);
        }
        public IEnumerable<AcamDTO> FiltrarRegistrosPorValor(decimal valorMinimo, int idFile)
        {
            return _repository.FiltrarRegistrosPorValor(valorMinimo, idFile);
        }

        public void InserirNaTabelaRestritiva(decimal valorMinimo, int idFile)
        {
            _repository.InserirNaTabelaRestritiva(valorMinimo,idFile);
        }

        public void SalvarNaTabelaRestritiva(decimal valorMaximo, int idFile)
        {
            _repository.SalvarNaTabelaRestritiva(valorMaximo, idFile);
        }

        public void GerarRelatorioSaidaProcessamento(int idFile)
        {
            _repository.GerarRelatorioSaidaProcessamento(idFile);
        }

        public DataTable GerarRelatorioVisualTotal(int idFile)
        {
            return _repository.GerarRelatorioVisualTotal(idFile);
        }
        public DataTable GerarRelatorioVisualNaoProcessados(int idFile)
        {
            return _repository.GerarRelatorioVisualNaoProcessados(idFile);
        }
        public DataTable ListarArquivosJaProcessadosDoBanco()
        {
            return _repository.ListarArquivosJaProcessadosDoBanco();
        }

        public IEnumerable<AcamDTO> ConsultaBaseRestritra(string dataInicial, string dataFinal, string documento)
        {
            return _repository.ConsultaBaseRestritra(dataInicial, dataFinal, documento);
        }

        public IEnumerable<AcamDTO> ConsultaBaseGeral(string dataInicial, string dataFinal, int documento)
        {
            return _repository.ConsultaBaseGeral(dataInicial, dataFinal, documento);
        }

        public void GerarRelatorio(int idArquivo, string caminhoArquivo)
        {
            _repository.GerarRelatorio(idArquivo, caminhoArquivo);
        }
        public void ForcaImportacaoRestritiva(int idArquivo)
        {
            _repository.ForcaImportacaoRestritiva(idArquivo);
        }
    }
}
