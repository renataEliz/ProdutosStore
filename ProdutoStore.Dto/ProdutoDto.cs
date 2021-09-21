using ProdutoStore.Model.Entidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProdutoStore.Dto
{
    public class ProdutoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe Descrição")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe se o produto é ativo")]
        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Informe Perecível")]
        [DisplayName("Perecivel?")]
        public bool Perecivel { get; set; }

        [Required(ErrorMessage = "Informe Categoria")]
        [DisplayName("Categoria Produto")]
        public int CategoriaId { get; set; }

        public List<Categoria> Categorias { get; set; }

        public List<ProdutoListaDto> Produtos { get; set; }
    }
}
