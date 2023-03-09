using MediatR;
using System;

namespace GloboTicket.TicketManagement.Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest
    {
        public Guid EmployeeId { get; set; }
    }
}
