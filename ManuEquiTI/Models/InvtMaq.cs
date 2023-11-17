using System.ComponentModel.DataAnnotations;

namespace ManuEquiTI.Models
{
    public class InvtMaq
    {
        [Key]
        public int idMaq { get; set; }
        public string Maquina { get; set; }
        public string CodMaq { get; set; }
        public string Observacoes { get; set; }
        
    }
}
