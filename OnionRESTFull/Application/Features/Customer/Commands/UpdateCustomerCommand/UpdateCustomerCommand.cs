using MediatR;

namespace Application.Features.Customer.Commands.UpdateCustomerCommand
{
    public class UpdateCustomerCommand : INotification
    {
        public Guid Id
        {
            get;
            set;
        }

        public string? Name
        {
            get;
            set;
        }

        public string? LastName
        {
            get;
            set;
        }

        public DateTime BirthdayDate
        {
            get;
            set;
        }

        public string? Phone
        {
            get;
            set;
        }

        public string? Email
        {
            get;
            set;
        }

        public string? Address
        {
            get;
            set;
        }
    }
}