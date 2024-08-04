using Application.Dtos.Human;
using Application.Interfaces.Humans;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Human.Queries
{
    public class ArrayHumanQuery : IRequest<Response<List<HumanResponse>>>
    {

    }
    
    public class ArrayHumanQueryHandler : IRequestHandler<ArrayHumanQuery, Response<List<HumanResponse>>>
    {
        private readonly IHumanRepository _humanRepository;
        private readonly IMapper _mapper;

        public ArrayHumanQueryHandler(IHumanRepository humanRepository, IMapper mapper)
        {
            _humanRepository = humanRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<HumanResponse>>> Handle(ArrayHumanQuery request, CancellationToken cancellationToken)
        {
            var arrayHumanResponse = _humanRepository.ArrayHumansAsync();
            if (!arrayHumanResponse.Any())
            {
                throw new Exception("Array Human Not Found.");
            }
            var dto = _mapper.Map<List<HumanResponse>>(arrayHumanResponse);
            return new Response<List<HumanResponse>>(dto);
        }
    }
}
