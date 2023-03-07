using FluentValidation;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeCommandValidator(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.DateofBirth)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(e => e)
                .MustAsync(EmpoyeeNameUnique)
                .WithMessage("An event with the same name and date already exists.");


        }

        private async Task<bool> EmpoyeeNameUnique(CreateEmployeeCommand e, CancellationToken token)
        {
            return !(await _employeeRepository.IsEmployeeNameUnique(e.Name));
        }
    }
}
