using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<Response<CustomerDTO>>
    {
        public Guid Id { get; set; }
        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Response<CustomerDTO>>
        {
            public GetCustomerByIdQueryHandler(IRepositoryAsync<Domain.Entities.Customer> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<CustomerDTO>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
            {
                var customer = await _repositoryAsync.GetByIdAsync(request.Id, cancellationToken);
                if (customer != null)
                {
                    var customerDTO = _mapper.Map<CustomerDTO>(customer);
                    return new Response<CustomerDTO>(customerDTO);
                }
                else
                {
                    throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
                }
            }

            private readonly IRepositoryAsync<Domain.Entities.Customer> _repositoryAsync;
            private readonly IMapper _mapper;
        }
    }
}