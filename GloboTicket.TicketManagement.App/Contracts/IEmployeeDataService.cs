using GloboTicket.TicketManagement.App.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.App.Contracts
{
    public interface IEmployeeDataService
    {
        Task<List<EmployeeListViewModel>> GetAllEmployees();
    }
}
