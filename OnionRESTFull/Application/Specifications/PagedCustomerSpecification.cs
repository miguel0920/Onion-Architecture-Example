using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class PagedCustomerSpecification : Specification<Customer>
    {
        public PagedCustomerSpecification(int pageNumber, int pageSize, string? name, string? lastname)
        {
            Query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!string.IsNullOrEmpty(name))
                Query.Search(x => x.Name, $"%{name}%");

            if (!string.IsNullOrEmpty(lastname))
                Query.Search(x => x.LastName, $"%{lastname}%");
        }
    }
}