using MediatR;
using System.Collections.Generic;

namespace GloboTicket.TicketManagement.Application.Features.Employees.Queries.GetEmployeesList
{

    public class GetEmployeeListQuery : IRequest<List<EmployeeListVm>>
    {

    }
}
