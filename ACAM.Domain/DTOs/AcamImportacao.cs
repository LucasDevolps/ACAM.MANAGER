namespace ACAM.Domain.DTOs
{
    public class AcamImportacao
    {
        public List<AcamDTO> Processadas { get; set; }
        public List<AcamDTO> NaoProcessadas { get; set; }

    }
}
