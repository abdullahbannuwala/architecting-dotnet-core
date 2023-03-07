using GloboTicket.TicketManagement.Domain.Common;
using System;

namespace GloboTicket.TicketManagement.Domain.Entities
{
    public class Employee : AuditableEntity
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateofBirth { get; set; }

    }
}
