using ProdutoStore.DA.Context;

namespace ProdutoStore.DA.Seeders
{
    public interface ISeeder
    {
        void Seed(ProdutoStoreContext context);
    }
}
