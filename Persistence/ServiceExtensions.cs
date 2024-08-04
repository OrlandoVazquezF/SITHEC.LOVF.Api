using Application.Interfaces.Common;
using Application.Interfaces.Humans;
using Application.Interfaces.MathOperations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Database
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IMathOperationRepository, MathOperationRepository>();
            services.AddTransient<IHumanRepository, HumanRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion
        }
    }
}
