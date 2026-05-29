using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCRUDMVCSQL.Models
{
    [Table("Pedido")]
   
    public class Pedido
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Clientes Cliente { get; set; }


        [Display(Name = "Usuário")]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuarios Usuario { get; set; }


        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }


        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        // Valor Total Compra
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Valor Total")]
        public decimal ValorTotal { get; set; }


        [Display(Name = "Data do Pedido")]
        public DateTime DataPedido { get; set; }
    }
}
