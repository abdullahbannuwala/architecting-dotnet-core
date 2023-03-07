using GloboTicket.TicketManagement.Domain.Entities;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Contracts.Persistence
{

    public interface IEmployeeRepository : IAsyncRepository<Employee>
    {
        Task<bool> IsEmployeeNameUnique(string name);
    }
}
