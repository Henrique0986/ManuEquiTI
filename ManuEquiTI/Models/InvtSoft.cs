using System.ComponentModel.DataAnnotations;

namespace ManuEquiTI.Models
{
    public class InvtSoft
    {
        [Key]
        public int idSoft { get; set; }
        public string SoftWare { get; set; }
        public string CodSoft{ get; set; }
        public string Observacoes { get; set; }
    }
}
