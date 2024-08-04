using Application.Features.MathOperation.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MathOperationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MathOperationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> MathOperationBasicPostAsync([FromBody] MathOperationQuery filter)
        {
            return Ok(await _mediator.Send(filter));
        }

        [HttpGet]
        public async Task<IActionResult> MathOperationBasicGetAsync([FromHeader] string type, decimal parameterA, decimal parameterB)
        {
            return Ok(await _mediator.Send(new MathOperationQuery { TypeOperation = type, ParameterA = parameterA, ParameterB = parameterB}));
        }
    }
}
