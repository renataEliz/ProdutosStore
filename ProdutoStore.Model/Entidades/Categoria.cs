
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProdutoStore.Model.Entidades
{
    [Table("tblCategoriaProduto")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Nome { get; set; }

        [MaxLength(250)]
        [Required]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
    }
}
