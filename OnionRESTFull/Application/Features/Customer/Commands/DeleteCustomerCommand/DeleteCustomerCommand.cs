using MediatR;

namespace Application.Features.Customer.Commands.DeleteCustomerCommand
{
    public class DeleteCustomerCommand : INotification
    {
        public Guid Id
        {
            get;
            set;
        }
    }
}