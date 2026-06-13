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

        [Range(1, 1000,
       ErrorMessage = "A quantidade deve ser entre 1 e 1000")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        // Valor Total Compra
        [Range(0.01, 999999,
       ErrorMessage = "O valor total deve ser maior que zero")]
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Valor Total")]
        public decimal ValorTotal { get; set; }


        [Display(Name = "Data do Pedido")]
        public DateTime DataPedido { get; set; }
    }
}
