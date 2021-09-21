using ProdutoStore.Core;
using ProdutoStore.Core.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoStore.DA.Repositorio
{
    public abstract class RepositorioAbstrato<T, TDBContext> : IRepositorio<T>
        where T : class
        where TDBContext : DbContext
    {
        private readonly IUnitOfWork<TDBContext> unitOfWork;

        public RepositorioAbstrato(IUnitOfWork<TDBContext> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Adicionar(T entidade)
        {
            this.unitOfWork.Adicionar(entidade);
        }

        public void Atualizar(T entidade)
        {
            this.unitOfWork.Atualizar(entidade);
        }

        public void Excluir(T entidade)
        {
            this.unitOfWork.Excluir(entidade);
        }

        public async Task<IList<T>> ListarTodosAsync()
        {
            return await this.unitOfWork.ListarTodosAsync<T>();
        }

        public IQueryable<T> Pesquisar(Expression<Func<T, bool>> where = null)
        {
            return this.unitOfWork.Pesquisar(where);
        }

        public async Task<T> PesquisarEntidadeAsync(Expression<Func<T, bool>> where)
        {
            return await this.unitOfWork.PesquisarEntidadeAsync(where);
        }

        public void BeginTransaction()
        {
            this.unitOfWork.BeginTransaction();
        }

        public async Task CommitAsync()
        {
            await this.unitOfWork.CommitAsync();
        }

        public void Rollback()
        {
            this.unitOfWork.Rollback();
        }

        public async Task SalvarAsync()
        {
            await this.unitOfWork.SaveAsync();
        }
    }
}
