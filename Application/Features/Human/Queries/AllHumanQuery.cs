using Application.Dtos.Human;
using Application.Interfaces.Humans;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Human.Queries
{
    public class AllHumanQuery : IRequest<Response<IEnumerable<HumanResponse>>>
    {

    }

    public class AllHumanQueryHandler : IRequestHandler<AllHumanQuery, Response<IEnumerable<HumanResponse>>>
    {
        private readonly IHumanRepository _humanRepository;
        private readonly IMapper _mapper;

        public AllHumanQueryHandler(IHumanRepository humanRepository, IMapper mapper)
        {
            _humanRepository = humanRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<HumanResponse>>> Handle(AllHumanQuery request, CancellationToken cancellationToken)
        {
            var allHumanResponse = await _humanRepository.AllHumansAsync();
            if (!allHumanResponse.Any())
            {
                throw new Exception("Human Data Not Found.");
            }
            var dto = _mapper.Map<IEnumerable<HumanResponse>>(allHumanResponse);
            return new Response<IEnumerable<HumanResponse>>(dto);
        }
    }
}
