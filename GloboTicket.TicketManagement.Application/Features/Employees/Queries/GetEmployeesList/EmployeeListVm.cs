using System;

namespace GloboTicket.TicketManagement.Application.Features.Employees.Queries.GetEmployeesList
{
    public class EmployeeListVm
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateofBirth { get; set; }
    }
}
