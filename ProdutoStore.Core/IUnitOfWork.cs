using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProdutoStore.Core
{
    public interface IUnitOfWork<TDbContext> where TDbContext : IDisposable
    {
        void Adicionar<T>(T entidade) where T : class;
        void Atualizar<T>(T entidade) where T : class;
        void Excluir<T>(T entidade) where T : class;
        void BeginTransaction();
        Task CommitAsync();      
        Task<List<T>> ListarTodosAsync<T>() where T : class;
        IQueryable<T> Pesquisar<T>(Expression<Func<T, bool>> where = null) where T : class;
        Task<T> PesquisarEntidadeAsync<T>(Expression<Func<T, bool>> where) where T : class;
        void Rollback();
        Task SaveAsync();
    }
}
