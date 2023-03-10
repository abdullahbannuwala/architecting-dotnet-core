using AutoMapper;
using Blazored.LocalStorage;
using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.Services.Base;
using GloboTicket.TicketManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.App.Services
{
    public class EmployeeDataService : BaseDataService, IEmployeeDataService
    {

        private readonly IMapper _mapper;

        public EmployeeDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<EmployeeListViewModel>> GetAllEmployees()
        {
            var allEmployee = await _client.GetAllEmployeesAsync();
            var mappedEmployee = _mapper.Map<ICollection<EmployeeListViewModel>>(allEmployee);
            return mappedEmployee.ToList();
        }

        public async Task<ApiResponse<Guid>> CreateEmployee(EmployeeDetailViewModel employeeDetailViewModel)
        {
            try
            {
                CreateEmployeeCommand createEmployeeCommand = _mapper.Map<CreateEmployeeCommand>(employeeDetailViewModel);
                var newId = await _client.AddEmployeeAsync(createEmployeeCommand);
                return new ApiResponse<Guid>() { Data = newId, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

    }
}
