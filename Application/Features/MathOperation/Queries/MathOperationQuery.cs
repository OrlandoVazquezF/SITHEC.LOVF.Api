using Application.Interfaces.MathOperations;
using Application.Parameters.MathOperation;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MathOperation.Queries
{
    public class MathOperationQuery : MathOperationParameter, IRequest<Response<decimal>>
    {
        public class MathOperationQueryHandler : IRequestHandler<MathOperationQuery, Response<decimal>>
        {
            private readonly IMathOperationRepository _mathOperationRepository;

            public MathOperationQueryHandler(IMathOperationRepository mathOperationRepository)
            {
                _mathOperationRepository = mathOperationRepository;
            }

            public async Task<Response<decimal>> Handle(MathOperationQuery request, CancellationToken cancellationToken)
            {
                decimal result;
                if (request.TypeOperation == "S")
                {
                    result = await _mathOperationRepository.SumAsync(request.ParameterA, request.ParameterB);
                }
                else if (request.TypeOperation == "R")
                {
                    result = await _mathOperationRepository.SubtractionAsync(request.ParameterA, request.ParameterB);
                }
                else if (request.TypeOperation == "D")
                {
                    result = await _mathOperationRepository.DivisionAsync(request.ParameterA, request.ParameterB);
                }
                else if (request.TypeOperation == "M")
                {
                    result = await _mathOperationRepository.MultiplicationAsync(request.ParameterA, request.ParameterB);
                }
                else 
                {
                    throw new Exception("Type Math Operation Not Supported.");               
                }

                return new Response<decimal>(result);
            }
        }
    }
}
