using ProdutoStore.Core;
using ProdutoStore.Core.BR;
using ProdutoStore.Core.Repositorio;
using ProdutoStore.DA.Context;
using ProdutoStore.DA.Repositorio;
using ProdutoStore.DA.UnitOfWork;
using ProdutoStore.Model.Entidades;
using PrudutoStore.Implementacao.BR;
using SimpleInjector;


namespace ProdutoStore.Web.Extensoes
{
    public static class ContainerExtensao
    {
        public static void RegistrarDependencias(this Container container)
        {
            RegistrarDbContexts(container);
            RegistrarUnitOfWork(container);
            RegistrarBusinessRules(container);
            RegistrarRepositorios(container);
        }

        private static void RegistrarDbContexts(Container container)
        {
            container.Register(() => new ProdutoStoreContext(), Lifestyle.Scoped);

        }

        private static void RegistrarUnitOfWork(Container container)
        {
            container.Register<IUnitOfWork<ProdutoStoreContext>, ProdutoStoreUnitOfWork>(Lifestyle.Scoped);
        }

        private static void RegistrarBusinessRules(Container container)
        {
            container.Register<IProdutoBR, ProdutoBR>();
            container.Register<ICategoriaBR, CategoriaBR>();
        }

        private static void RegistrarRepositorios(Container container)
        {
            container.Register<IRepositorio<Produto>, ProdutoRepositorio>();
            container.Register<IRepositorio<Categoria>, CategoriaRepositorio>();
        }
    }
}