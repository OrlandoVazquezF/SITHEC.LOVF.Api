using Application.Features.Human.Command;
using Application.Features.Human.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HumanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ArrayHumanAsync()
        {
            return Ok(await _mediator.Send(new ArrayHumanQuery()));
        }

        [HttpGet]
        public async Task<IActionResult> AllHumanAsync()
        {
            return Ok(await _mediator.Send(new AllHumanQuery()));
        }

        [HttpGet]
        public async Task<IActionResult> HumanByIdAsync(int Id)
        {
            return Ok(await _mediator.Send(new HumanQuery() { Id = Id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateHumanAsync([FromBody] CreateHumanCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHumanAsync([FromBody] UpdateHumanCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
