using MediatR;
using System;

namespace GloboTicket.TicketManagement.Application.Features.Employees.Queries.GetEmployeeDetail
{
    public class GetEmployeeDetailQuery : IRequest<EmployeeDetailVm>
    {
        public Guid Id { get; set; }
    }
}
