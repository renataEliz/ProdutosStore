using ProdutoStore.DA.Context;
using ProdutoStore.DA.Seeders;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ProdutoStore.DA.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ProdutoStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProdutoStoreContext context)
        {
            var seeders = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(ISeeder).IsAssignableFrom(x)
                    && !x.IsInterface
                    && !x.IsAbstract)
                .ToList();
            foreach (var seeder in seeders)
            {
                (Activator.CreateInstance(seeder) as ISeeder).Seed(context);
            }
        }
    }
}
