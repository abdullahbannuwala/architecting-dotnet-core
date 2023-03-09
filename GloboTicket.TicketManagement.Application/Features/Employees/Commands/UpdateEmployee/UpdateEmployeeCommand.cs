using MediatR;
using System;

namespace GloboTicket.TicketManagement.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateofBirth { get; set; }
    }
}
