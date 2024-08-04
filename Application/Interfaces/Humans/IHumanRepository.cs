using Application.Interfaces.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Humans
{
    public interface IHumanRepository : IGenericRepository<Human>
    {
        List<Human> ArrayHumansAsync();
        Task<IEnumerable<Human>> AllHumansAsync();
        Task<Human> HumanAsync(int id);
    }
}
