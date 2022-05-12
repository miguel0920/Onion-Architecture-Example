using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomerQuery : IRequest<PageResponse<List<CustomerDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, PageResponse<List<CustomerDTO>>>
        {
            public GetAllCustomerQueryHandler(IRepositoryAsync<Domain.Entities.Customer> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<PageResponse<List<CustomerDTO>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
            {
                var customer = await _repositoryAsync.ListAsync(new PagedCustomerSpecification(request.PageNumber, request.PageSize, request.Nombre, request.Apellido), cancellationToken);
                var customerDTO = _mapper.Map<List<CustomerDTO>>(customer);
                return new PageResponse<List<CustomerDTO>>(customerDTO, request.PageNumber, request.PageSize);
            }

            private readonly IRepositoryAsync<Domain.Entities.Customer> _repositoryAsync;
            private readonly IMapper _mapper;
        }
    }
}