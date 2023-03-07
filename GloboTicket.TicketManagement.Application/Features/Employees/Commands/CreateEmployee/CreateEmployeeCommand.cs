using MediatR;
using System;

namespace GloboTicket.TicketManagement.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateofBirth { get; set; }

        public override string ToString()
        {
            return $"Employee name: {Name}";
        }


    }
}
