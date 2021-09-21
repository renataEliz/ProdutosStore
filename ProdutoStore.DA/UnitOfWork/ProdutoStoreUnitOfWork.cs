using ProdutoStore.Core;
using ProdutoStore.DA.Context;


namespace ProdutoStore.DA.UnitOfWork
{
    public class ProdutoStoreUnitOfWork : AbstractUnitOfWork<ProdutoStoreContext>,
        IUnitOfWork<ProdutoStoreContext>
    {

        public ProdutoStoreUnitOfWork(ProdutoStoreContext dbContext) : base(dbContext)
        {
        }
     
    }
}
