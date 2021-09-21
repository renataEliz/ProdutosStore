using ProdutoStore.Model.Entidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;


namespace ProdutoStore.DA.Context
{
    public partial class ProdutoStoreContext : DbContext
    {
        public ProdutoStoreContext() : base("ProdutoStore")
        {
            this.Database.Log = s => Debug.Write(s);
        }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
