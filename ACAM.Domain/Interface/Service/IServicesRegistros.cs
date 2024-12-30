using ACAM.Domain.DTOs;
using System.Data;

namespace ACAM.Domain.Interface.Service
{
    public interface IServicesRegistros
    {
        void ProcessarCsvPorStreaming(string caminhoCsv, int idArquivo);

        void SalvarNoBanco(List<AcamDTO> buffer, int idArquivo);

        IEnumerable<AcamDTO> FiltrarRegistrosPorValor(decimal valorMinimo, int idFile);

        void InserirNaTabelaRestritiva(decimal valorMinimo, int idFile);

        void SalvarNaTabelaRestritiva(decimal valorMaximo, int idFile);
        void GerarRelatorioSaidaProcessamento(int idFile);

        DataTable GerarRelatorioVisualTotal(int idFile);

        DataTable GerarRelatorioVisualNaoProcessados(int idFile);

        DataTable ListarArquivosJaProcessadosDoBanco();

        IEnumerable<AcamDTO> ConsultaBaseRestritra(string dataInicial, string dataFinal, string documento);

        IEnumerable<AcamDTO> ConsultaBaseGeral(string dataInicial, string dataFinal, int documento);

        void GerarRelatorio(int idFile, string caminho);

        void ForcaImportacaoRestritiva(int idArquivo);

        Task ImportarCAF(List<AcamRestritivaCAFDTO> buffer);

        void ProcessaCAFCSV(int idArquivo, string caminho);

        void NovoProcessarCsvPorStreaming(string caminhoCsv, int idArquivo);
    }
}
