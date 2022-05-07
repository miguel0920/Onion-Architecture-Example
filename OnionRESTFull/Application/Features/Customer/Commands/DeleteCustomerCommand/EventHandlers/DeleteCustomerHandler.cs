using Application.Interfaces;
using MediatR;

namespace Application.Features.Customer.Commands.DeleteCustomerCommand.EventHandlers
{
    public class DeleteCustomerHandler : INotificationHandler<DeleteCustomerCommand>
    {
        public DeleteCustomerHandler(IRepositoryAsync<Domain.Entities.Customer> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task Handle(DeleteCustomerCommand notification, CancellationToken cancellationToken)
        {
            var customer = await _repositoryAsync.GetByIdAsync(notification.Id, cancellationToken);
            if (customer == null)
                throw new KeyNotFoundException($"Registro no encontrado con el Id {notification.Id}");
            else
            {
                await _repositoryAsync.DeleteAsync(customer, cancellationToken);
            }
        }

        private readonly IRepositoryAsync<Domain.Entities.Customer> _repositoryAsync;
    }
}