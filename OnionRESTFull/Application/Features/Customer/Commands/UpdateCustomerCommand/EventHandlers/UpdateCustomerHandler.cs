using Application.Interfaces;
using MediatR;

namespace Application.Features.Customer.Commands.UpdateCustomerCommand.EventHandlers
{
    public class UpdateCustomerHandler : INotificationHandler<UpdateCustomerCommand>
    {
        public UpdateCustomerHandler(IRepositoryAsync<Domain.Entities.Customer> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task Handle(UpdateCustomerCommand notification, CancellationToken cancellationToken)
        {
            var customer = await _repositoryAsync.GetByIdAsync(notification.Id, cancellationToken);
            if (customer == null)
                throw new KeyNotFoundException($"Registro no encontrado con el Id {notification.Id}");
            else
            {
                customer.Name = notification.Name;
                customer.LastName = notification.LastName;
                customer.BirthdayDate = notification.BirthdayDate;
                customer.Phone = notification.Phone;
                customer.Email = notification.Email;
                customer.Address = notification.Address;

                await _repositoryAsync.UpdateAsync(customer);
            }
        }

        private readonly IRepositoryAsync<Domain.Entities.Customer> _repositoryAsync;
    }
}