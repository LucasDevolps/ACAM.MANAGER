namespace ACAM.Domain.DTOs
{
    public class AcamRestritivaCAFDTO
    {
        public string ID { get; set; }                 
        public DateTime? CriadoEm { get; set; }     
        public DateTime? AtualizadoEm { get; set; } 
        public string CriadoPor { get; set; }       
        public string Nome { get; set; }           
        public string CPFCNPJ { get; set; }        
        public string Status { get; set; }         
        public string Mensagem { get; set; }       
        public string MotivoReprovacao { get; set; }
        public string URLTrust { get; set; }       
        public int IdArquivo { get; set; }   
        public bool ind_positivo { get; set; }
    }
}
