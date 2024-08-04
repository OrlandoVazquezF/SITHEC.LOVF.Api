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
    public class HumanQuery : IRequest<Response<HumanResponse>>
    {
        public int Id { get; set; }
    }

    public class HumanQueryHandler : IRequestHandler<HumanQuery, Response<HumanResponse>>
    {
        private readonly IHumanRepository _humanRepository;
        private readonly IMapper _mapper;

        public HumanQueryHandler(IHumanRepository humanRepository, IMapper mapper)
        {
            _humanRepository = humanRepository;
            _mapper = mapper;
        }

        public async Task<Response<HumanResponse>> Handle(HumanQuery request, CancellationToken cancellationToken)
        {
            var humanResponse = await _humanRepository.HumanAsync(request.Id);
            var dto = new HumanResponse();
            if (humanResponse == null)
            {
                throw new Exception("Human ID Not Found.");
            }
            else
            {
                dto = _mapper.Map<HumanResponse>(humanResponse);
            }
            return new Response<HumanResponse>(dto);
        }
    }
}
