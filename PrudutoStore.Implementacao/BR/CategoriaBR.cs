using ProdutoStore.Core.BR;
using ProdutoStore.Core.Repositorio;
using ProdutoStore.Model.Entidades;

namespace PrudutoStore.Implementacao.BR
{
    public class CategoriaBR : BusinessRulesAbstrato<Categoria>, ICategoriaBR, IBusinessRules<Categoria>
    {
        public CategoriaBR(IRepositorio<Categoria> repositorio) : base(repositorio)
        {
        }
    }
}
