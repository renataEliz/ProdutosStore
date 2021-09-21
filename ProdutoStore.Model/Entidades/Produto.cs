
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProdutoStore.Model.Entidades
{
    [Table("tblProduto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Categoria))]
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }

        [MaxLength(250)]
        [Required]
        public string Nome { get; set; }

        [MaxLength(250)]
        [Required]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        public bool Perecivel { get; set; }
    }
}
