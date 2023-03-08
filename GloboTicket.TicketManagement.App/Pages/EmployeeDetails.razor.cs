using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.Services.Base;
using GloboTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.App.Pages
{
    public partial class EmployeeDetails
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public EmployeeDetailViewModel EmployeeDetailViewModel { get; set; }
            = new EmployeeDetailViewModel();



        public string Message { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }
        private Guid SelectedEmployeId = Guid.Empty;

        protected override async Task OnInitializedAsync()
        {


        }

        protected async Task HandleValidSubmit()
        {
            ApiResponse<Guid> response;

            if (SelectedEmployeId == Guid.Empty)
            {
                response = await EmployeeDataService.CreateEmployee(EmployeeDetailViewModel);
            }
            else
            {
                response = await EmployeeDataService.CreateEmployee(EmployeeDetailViewModel);
            }
            HandleResponse(response);

        }



        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.Success)
            {
                NavigationManager.NavigateTo("/employeeoverview");
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
    }
}
