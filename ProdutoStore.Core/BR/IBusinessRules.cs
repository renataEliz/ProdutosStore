using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoStore.Core.BR
{
    public interface IBusinessRules<T>
       where T : class
    {
        Task AdicionarAsync(T entidade);

        Task AtualizarAsync(T entidade);

        Task ExcluirAsync(T entidade);

        IQueryable<T> Pesquisar(Expression<Func<T, bool>> where = null);

        Task<T> PesquisarEntidadeAsync(Expression<Func<T, bool>> where);

        Task<IList<T>> ListarTodosAsync();
    }
}
