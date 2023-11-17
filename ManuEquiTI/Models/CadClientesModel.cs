using System.ComponentModel.DataAnnotations;

namespace ManuEquiTI.Models
{
    public class CadClientesModel : InvtMaq
    {
        [Key]
        public int idCli { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public List<InvtMaq> ListaMaq { get; set; }
        public List<InvtSoft> ListaSoft { get; set; }
    }
}
