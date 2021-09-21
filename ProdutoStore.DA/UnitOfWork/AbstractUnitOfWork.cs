using ProdutoStore.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoStore.DA.UnitOfWork
{
    public abstract class AbstractUnitOfWork<TDbContext> : IUnitOfWork<TDbContext>
        where TDbContext : DbContext
    {
        protected readonly TDbContext dbContext;
        private DbContextTransaction dbContextTransaction;

        public AbstractUnitOfWork(TDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Adicionar<T>(T entidade)
            where T : class
        {
            this.dbContext.Set<T>().Add(entidade);
        }

        public void Atualizar<T>(T entidade)
            where T : class
        {

            var registro = this.AnexarEntidade(entidade);
            registro.State = EntityState.Modified;
        }

        public void Excluir<T>(T entidade)
            where T : class
        {
            var registro = this.AnexarEntidade(entidade);
            registro.State = EntityState.Deleted;
        }

        public IQueryable<T> Pesquisar<T>(Expression<Func<T, bool>> where = null)
            where T : class
        {
            if (where != null)
            {
                return this.dbContext.Set<T>().Where(where);
            }

            return this.dbContext.Set<T>();
        }

        public void BeginTransaction()
        {
            if (this.dbContextTransaction == null)
            {
                this.dbContextTransaction = this.dbContext.Database.BeginTransaction();
            }
        }

        public async Task CommitAsync()
        {
            await this.dbContext.SaveChangesAsync();
            if (this.dbContextTransaction != null)
            {
                this.dbContextTransaction.Commit();
                this.CleanTransaction();
            }
        }

        public void Rollback()
        {
            if (this.dbContextTransaction != null)
            {
                this.dbContextTransaction.Rollback();
                this.CleanTransaction();
            }
        }

        public virtual async Task SaveAsync()
        {
            try
            {
                await this.dbContext.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entidade do tipo \"{0}\" com estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Propriedade: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public async Task<List<T>> ListarTodosAsync<T>() where T : class
        {
            return await this.dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> PesquisarEntidadeAsync<T>(Expression<Func<T, bool>> where) where T : class
        {
            return await this.dbContext.Set<T>().FirstOrDefaultAsync(where);
        }

        private void CleanTransaction()
        {
            this.dbContextTransaction?.Dispose();
            this.dbContextTransaction = null;
        }

        private DbEntityEntry<T> AnexarEntidade<T>(T entidade)
           where T : class
        {
            var registro = this.dbContext.Entry(entidade);
            if (registro == null || registro.State == EntityState.Detached)
            {
                this.dbContext.Set<T>().Attach(entidade);
            }

            return registro;
        }
    }
}
