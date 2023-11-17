using System.ComponentModel.DataAnnotations;

namespace ManuEquiTI.Models
{
    public class CadClientes
    {
        [Key]
        public int idCli {  get; set; }
        public int idMaq { get; set; }
        public int idSoft { get; set; }
        public string Nome { get; set;}
        public string Endereco { get; set;}
        public string CPF { get; set;}
        public  string Telefone { get; set;}

    }
}
