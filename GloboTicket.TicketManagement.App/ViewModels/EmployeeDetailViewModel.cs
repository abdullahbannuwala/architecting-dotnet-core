using System;
using System.ComponentModel.DataAnnotations;

namespace GloboTicket.TicketManagement.App.ViewModels
{
    public class EmployeeDetailViewModel
    {
        public Guid EmployeeId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The name of the employee should be 50 characters or less")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The email of the employee should be 50 characters or less")]
        public string Email { get; set; }
        public DateTime DateofBirth { get; set; }




    }
}
