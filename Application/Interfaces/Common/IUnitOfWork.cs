using Application.Interfaces.Humans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IHumanRepository HumanRepository { get; } 

        Task<int> Commit(CancellationToken cancellationToken);

        Task RollBack();
    }
}
