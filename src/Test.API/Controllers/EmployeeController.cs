using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Test.API.DTOs.Errors;
using Test.Application.Commands.Employee;
using Test.Application.DTOs.Employee;

namespace Test.API.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;

        [HttpPost]
        [ProducesResponseType(typeof(EmployeeDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestResponseDTO), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<CreateEmployeeResponse>> Create(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
