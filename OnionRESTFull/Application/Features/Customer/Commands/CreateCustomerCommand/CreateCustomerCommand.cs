using Application.Wrappers;
using MediatR;

namespace Application.Features.Customer.Commands.CreateCustomerCommand
{
    public class CreateCustomerCommand : IRequest<Response<int>>
    {
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

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<int>>
    {
        public Task<Response<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}