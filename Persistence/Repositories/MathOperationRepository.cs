using Application.Interfaces.MathOperations;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class MathOperationRepository : IMathOperationRepository
    {
        public async Task<decimal> DivisionAsync(decimal parameterA, decimal parameterB)
        {
            return await Task.FromResult(parameterA / parameterB);
        }

        public async Task<decimal> MultiplicationAsync(decimal parameterA, decimal parameterB)
        {
            return await Task.FromResult(parameterA * parameterB);
        }

        public async Task<decimal> SubtractionAsync(decimal parameterA, decimal parameterB)
        {
            return await Task.FromResult(parameterA - parameterB);
        }

        public async Task<decimal> SumAsync(decimal parameterA, decimal parameterB)
        {
            return await Task.FromResult(parameterA + parameterB);
        }
    }
}
