using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProdutoStore.Core.Repositorio
{
    public interface IRepositorio<T>
    {
        void Adicionar(T entidade);

        void Atualizar(T entidade);

        IQueryable<T> Pesquisar(Expression<Func<T, bool>> where = null);

        Task<T> PesquisarEntidadeAsync(Expression<Func<T, bool>> where);

        void BeginTransaction();

        Task CommitAsync();

        void Rollback();

        Task SalvarAsync();

        void Excluir(T entidade);

        Task<IList<T>> ListarTodosAsync();
    }
}
