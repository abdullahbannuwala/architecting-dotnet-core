using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Exceptions;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;


        public UpdateEmployeeCommandHandler(IMapper mapper, IAsyncRepository<Employee> employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }


        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {

            var empooyeeToUpdate = await _employeeRepository.GetByIdAsync(request.EmployeeId);

            if (empooyeeToUpdate == null)
            {
                throw new NotFoundException(nameof(Employee), request.EmployeeId);
            }

            var validator = new UpdateEmployeeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, empooyeeToUpdate, typeof(UpdateEmployeeCommand), typeof(Employee));

            await _employeeRepository.UpdateAsync(empooyeeToUpdate);

            return Unit.Value;
        }

    }
}
