using Application.Interfaces.Common;
using Application.Interfaces.Humans;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Human.Command
{
    public class CreateHumanCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
    }

    public class CreateHumanCommandHandler : IRequestHandler<CreateHumanCommand, Response<int>>
    {
        private IUnitOfWork _unitOfWork { get; set; }
        private readonly IMapper _mapper;

        public CreateHumanCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateHumanCommand request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Domain.Entities.Human>(request);
            await _unitOfWork.HumanRepository.AddAsync(data);
            await _unitOfWork.Commit(cancellationToken);
            return new Response<int>(data.Id);
        }
    }
}
