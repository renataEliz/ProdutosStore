using ProdutoStore.Core;
using ProdutoStore.Core.Repositorio;
using ProdutoStore.DA.Context;
using ProdutoStore.Model.Entidades;

namespace ProdutoStore.DA.Repositorio
{
    public class CategoriaRepositorio : RepositorioAbstrato<Categoria, ProdutoStoreContext>,
        IRepositorio<Categoria>
    {
        public CategoriaRepositorio(IUnitOfWork<ProdutoStoreContext> unitOfWork)
           : base(unitOfWork)
        {
        }
    }
}
