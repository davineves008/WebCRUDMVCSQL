using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCRUDMVCSQL.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "O nome deve ter entre 3 e 100 caracteres")]
        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Range(0.01, 999999,
            ErrorMessage = "O peso deve ser maior que zero")]
        [Column("Peso", TypeName = "Decimal(10,2)")]
        [Display(Name = "Peso")]
        [DisplayFormat(DataFormatString ="{0:n2}", ApplyFormatInEditMode = true)]
        public decimal Peso { get; set; }

        [Range(0.01, 999999,
            ErrorMessage = "O preço deve ser maior que zero")]
        [Column("Preço", TypeName = "Decimal(10,2)")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
    }
}