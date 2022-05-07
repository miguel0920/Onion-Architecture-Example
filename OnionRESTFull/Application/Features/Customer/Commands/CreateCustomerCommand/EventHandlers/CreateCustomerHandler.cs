using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Customer.Commands.CreateCustomerCommand.EventHandler
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Response<Guid>>
    {
        public CreateCustomerHandler(IMapper mapper, IRepositoryAsync<Domain.Entities.Customer> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerMapper = _mapper.Map<Domain.Entities.Customer>(request);
            var result = await _repositoryAsync.AddAsync(customerMapper, cancellationToken);
            return new Response<Guid> { Data = result.Id };
        }

        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Domain.Entities.Customer> _repositoryAsync;
    }
}