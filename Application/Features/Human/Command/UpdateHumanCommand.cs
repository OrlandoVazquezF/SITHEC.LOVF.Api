using Application.Interfaces.Common;
using Application.Interfaces.Humans;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Human.Command
{
    public class UpdateHumanCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
    }

    public class UpdateHumanCommandHandler : IRequestHandler<UpdateHumanCommand, Response<int>>
    {
        private readonly IHumanRepository _humanRepository;
        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateHumanCommandHandler(IHumanRepository humanRepository, IUnitOfWork unitOfWork)
        {
            _humanRepository = humanRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Response<int>> Handle(UpdateHumanCommand request, CancellationToken cancellationToken)
        {
            var humanResponse = _humanRepository.HumanAsync(request.Id).Result;
            if (humanResponse == null)
            {
                throw new Exception("Record Human ID Not Found.");
            }
            humanResponse.Name = request.Name;
            humanResponse.Sex = request.Sex;
            humanResponse.Age = request.Age;
            humanResponse.Weight = request.Weight;
            humanResponse.Height = request.Height;
            await _unitOfWork.HumanRepository.UpdateAsync(humanResponse);
            await _unitOfWork.Commit(cancellationToken);
            return new Response<int>(humanResponse.Id);
        }
    }
}
