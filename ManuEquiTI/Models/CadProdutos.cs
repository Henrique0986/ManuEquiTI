using System.ComponentModel.DataAnnotations;

namespace ManuEquiTI.Models
{
    public class CadProdutos 
    {
        [Key]
        public int idProd { get; set; }
        public string Produto { get; set;}
        public string Observacoes { get; set; }
    }
}
