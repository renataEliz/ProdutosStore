using ProdutoStore.Core.BR;
using ProdutoStore.Core.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrudutoStore.Implementacao.BR
{
    public abstract class BusinessRulesAbstrato<T> : IBusinessRules<T>
        where T : class
    {
        protected readonly IRepositorio<T> repositorio;

        public BusinessRulesAbstrato(IRepositorio<T> repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task AdicionarAsync(T entidade)
        {
            this.repositorio.Adicionar(entidade);
            await this.SalvarAsync();
        }

        public async Task AtualizarAsync(T entidade)
        {
            this.repositorio.Atualizar(entidade);
            await this.SalvarAsync();
        }

        public async Task ExcluirAsync(T entidade)
        {
            this.repositorio.Excluir(entidade);
            await this.SalvarAsync();
        }

        public async Task<IList<T>> ListarTodosAsync()
        {
            return await this.repositorio.ListarTodosAsync();
        }

        public IQueryable<T> Pesquisar(Expression<Func<T, bool>> where = null)
        {
            return this.repositorio.Pesquisar(where);
        }

        public async Task<T> PesquisarEntidadeAsync(Expression<Func<T, bool>> where)
        {
            return await this.repositorio.PesquisarEntidadeAsync(where);
        }

        protected void BeginTransaction()
        {
            this.repositorio.BeginTransaction();
        }

        protected async Task CommitAsync()
        {
            await this.repositorio.CommitAsync();
        }

        protected void Rollback()
        {
            this.repositorio.Rollback();
        }

        protected async Task SalvarAsync()
        {
            await this.repositorio.SalvarAsync();
        }
    }
}
