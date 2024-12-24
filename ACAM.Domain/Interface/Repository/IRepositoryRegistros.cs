using ACAM.Domain.DTOs;
using System.Data;

namespace ACAM.Domain.Interface.Repository
{
    public interface IRepositoryRegistros
    {
        void ProcessarCsvPorStreaming(string caminhoCsv, int idArquivo);

        void SalvarNoBanco(List<AcamDTO> buffer, int idArquivo);
        void salvarNaTabelaRestritiva(decimal valorMaximo, int idFile);
        void GerarRelatorioSaidaProcessamento(int idFile);
        DataTable GerarRelatorioVisualTotal(int idFile);

        DataTable GerarRelatorioVisualNaoProcessados(int idFile);


        IEnumerable<AcamDTO> FiltrarRegistrosPorValor(decimal valorMinimo, int idFile);
        void InserirNaTabelaRestritiva(decimal valorMinimo, int idFile);

        DataTable ListarArquivosJaProcessadosDoBanco();

       IEnumerable<AcamDTO> ConsultaBaseRestritra(string dataInicial, string dataFinal, string documento);

       IEnumerable<AcamDTO> ConsultaBaseGeral(string dataInicial, string dataFinal, int documento);
    }
}
