using ProdutoStore.Core;
using ProdutoStore.Core.Repositorio;
using ProdutoStore.DA.Context;
using ProdutoStore.Model.Entidades;

namespace ProdutoStore.DA.Repositorio
{
    public class ProdutoRepositorio : RepositorioAbstrato<Produto, ProdutoStoreContext>,
        IRepositorio<Produto>
    {
        public ProdutoRepositorio(IUnitOfWork<ProdutoStoreContext> unitOfWork)
           : base(unitOfWork)
        {
        }
    }
}
