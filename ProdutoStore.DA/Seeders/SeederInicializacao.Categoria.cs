using ProdutoStore.DA.Context;
using ProdutoStore.Model.Entidades;
using System.Linq;

namespace ProdutoStore.DA.Seeders
{
    public partial class SeederInicializacao
    {
        private void CriarCategoria(ProdutoStoreContext produtoStoreContext)
        {
            if (produtoStoreContext.Categorias.Any())
            {
                return;
            }

            produtoStoreContext.Categorias.Add(new Categoria
            {
                Nome = "Eletrônico",
                Descricao = "Eletrodoméstico",
                Ativo = true,
            });
            produtoStoreContext.Categorias.Add(new Categoria
            {
                Nome = "Informática",
                Descricao = "Produtos para Informática",
                Ativo = true,
            });
            produtoStoreContext.Categorias.Add(new Categoria
            {
                Nome = "Celulares",
                Descricao = "Aparelhos e acessórios",
                Ativo = true,
            });
            produtoStoreContext.Categorias.Add(new Categoria
            {
                Nome = "Moda",
                Descricao = "Artigos para vestuário em geral",
                Ativo = true,
            });
            produtoStoreContext.Categorias.Add(new Categoria
            {
                Nome = "Livros",
                Descricao = "Livros",
                Ativo = true,
            });
        }
    }
}
