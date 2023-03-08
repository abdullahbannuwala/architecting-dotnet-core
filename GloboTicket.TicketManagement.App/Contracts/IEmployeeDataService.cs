using GloboTicket.TicketManagement.App.Services.Base;
using GloboTicket.TicketManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.App.Contracts
{
    public interface IEmployeeDataService
    {
        Task<List<EmployeeListViewModel>> GetAllEmployees();
        Task<ApiResponse<Guid>> CreateEmployee(EmployeeDetailViewModel employeeDetailViewModel);
    }
}
