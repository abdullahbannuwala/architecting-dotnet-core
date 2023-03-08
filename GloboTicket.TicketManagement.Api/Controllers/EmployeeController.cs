using GloboTicket.TicketManagement.Application.Features.Employees.Commands.CreateEmployee;
using GloboTicket.TicketManagement.Application.Features.Employees.Queries.GetEmployeeDetail;
using GloboTicket.TicketManagement.Application.Features.Employees.Queries.GetEmployeesList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllEmployees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<EmployeeListVm>>> GetAllEmployees()
        {
            var dtos = await _mediator.Send(new GetEmployeeListQuery());
            return Ok(dtos);
        }



        [HttpPost(Name = "AddEmployee")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEmployeeCommand createEmployeeCommand)
        {
            var id = await _mediator.Send(createEmployeeCommand);
            return Ok(id);
        }

        [HttpGet("{id}", Name = "GetEmployeeById")]
        public async Task<ActionResult<EmployeeDetailVm>> GetEmployeeById(Guid id)
        {
            var getEmployeeDetailQuery = new GetEmployeeDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getEmployeeDetailQuery));
        }

    }
}
