using Application.Interfaces.Common;
using Application.Interfaces.Humans;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _dbContext;

        public IHumanRepository _humanRepository;
        private bool disposed;

        public UnitOfWork(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IHumanRepository HumanRepository => _humanRepository ??= new HumanRepository(_dbContext);

        public async Task<int> Commit(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task RollBack()
        {
            return Task.CompletedTask;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }
    }
}
