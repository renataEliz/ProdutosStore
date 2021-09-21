using ProdutoStore.DA.Context;

namespace ProdutoStore.DA.Seeders
{
    public  partial class SeederInicializacao : ISeeder
    {
        public void Seed(ProdutoStoreContext context)
        {
            CriarCategoria(context);
            context.SaveChanges();
        }
    }
}
