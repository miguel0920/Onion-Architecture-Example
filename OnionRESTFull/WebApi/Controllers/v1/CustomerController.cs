using Application.Features.Customer.Commands.CreateCustomerCommand;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CustomerController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerCommand createCustomer) => Ok(await Mediator.Send(createCustomer));
    }
}