using ACAM.Domain.DTOs;
using CsvHelper.Configuration;

namespace ACAM.Mapping
{
    public sealed class AcamDtoMap : ClassMap<AcamDTO>
    {
        public AcamDtoMap()
        {
            Map(m => m.Client).Name("Client", "Custumer");
            Map(m => m.Pix_Key).Name("pix_key", "pix key");
            Map(m => m.cpf_name).Name("cpf_name");
            Map(m => m.Amount).Name("amount");
            Map(m => m.TrnDate)
            .Name("trndate")
            .TypeConverterOption.Format("dd/MM/yyyy"); // Especifica o formato esperado da data
            Map(m => m.Id_file).Ignore(); // Ignorar campos não mapeados
            Map(m => m.ind_positivo).Ignore();
        }
    }
}
