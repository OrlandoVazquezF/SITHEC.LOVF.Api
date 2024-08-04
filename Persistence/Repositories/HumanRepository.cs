using Application.Interfaces.Humans;
using Ardalis.Specification.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class HumanRepository : GenericRepository<Human>, IHumanRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public HumanRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Human>> AllHumansAsync()
        {
            return await _dbContext.Human.ToListAsync();
        }

        public List<Human> ArrayHumansAsync()
        {
            List<Human> humans = new List<Human>()
            {
                new Human()
                {
                   Id = 1,
                   Name = "Luis Orlando Vazquez Flores",
                   Age = 33,
                   Sex = "M",
                   Height = 1.75m,
                   Weight = 95
                },
                new Human()
                {
                    Id = 2,
                   Name = "Juan Ramirez Peralta",
                   Age = 50,
                   Sex = "M",
                   Height = 1.69m,
                   Weight = 76
                },
                new Human()
                {
                    Id = 3,
                   Name = "Andrea Aguirre Jimenez",
                   Age = 12,
                   Sex = "F",
                   Height = 1.30m,
                   Weight = 26
                }
            };
            return humans;
        }

        public async Task<Human> HumanAsync(int id)
        {
            return await _dbContext.Human.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
