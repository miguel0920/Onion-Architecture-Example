using Application.Parameters;

namespace Application.Features.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomerQueryParameter : RequestParameter
    {
        public string? Nombre
        {
            get;
            set;
        }

        public string? Apellido
        {
            get;
            set;
        }
    }
}