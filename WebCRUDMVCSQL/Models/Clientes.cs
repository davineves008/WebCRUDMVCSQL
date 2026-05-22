using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCRUDMVCSQL.Models
{

    //Tabela clientes do banco de dados.
    [Table("Clientes")]
    public class Clientes
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }


        [Column("Idade")]

        [Display(Name = "Idade")]
        public int Idade { get; set; }

        [Column("Sexo")]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Column("Estado Civil")]
        [Display(Name = "Estado Civil")]
        public string Estado_Civil { get; set; }


        [Column("Endereco")]
        [Display(Name = "Endereco")]
        public string Endereco { get; set; }

        [Column("CEP")]
        [Display(Name = "CEP")]
        public int CEP { get; set; }

        [Column("Logradouro")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Column("Numero Casa")]
        [Display(Name = "Numero Casa")]
        public int Numero_Casa { get; set; }

        [Column("Complemento")]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Column("Bairro")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }


        [Column("Cidade")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Column("Estado")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Column("Pais")]
        [Display(Name = "Pais")]
        public string Pais { get; set; }



        [Column("Whatsapp")]
        [Display(Name = "Whatsapp")]
        public int Whatsapp { get; set; }


        [Column("CPF")]
        [Display(Name = "CPF")]
        public int CPF { get; set; }


        [Column("Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
