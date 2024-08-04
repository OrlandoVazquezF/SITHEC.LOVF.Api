using Application.Interfaces.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.MathOperations
{
    public interface IMathOperationRepository 
    {
        Task<decimal> SumAsync(decimal parameterA, decimal parameterB);
        Task<decimal> DivisionAsync(decimal parameterA, decimal parameterB);
        Task<decimal> MultiplicationAsync(decimal parameterA, decimal parameterB);
        Task<decimal> SubtractionAsync(decimal parameterA, decimal parameterB);
    }
}
