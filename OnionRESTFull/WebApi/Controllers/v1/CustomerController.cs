using Application.Features.Customer.Commands.CreateCustomerCommand;
using Application.Features.Customer.Commands.DeleteCustomerCommand;
using Application.Features.Customer.Commands.UpdateCustomerCommand;
using Application.Features.Customer.Queries.GetAllCustomers;
using Application.Features.Customer.Queries.GetCustomerById;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CustomerController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCustomerQueryParameter filter)
            => Ok(await Mediator
                .Send(new GetAllCustomerQuery { PageNumber = filter.PageNumber, PageSize = filter.PageSize, Nombre = filter.Nombre, Apellido = filter.Apellido }));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) => Ok(await Mediator.Send(new GetCustomerByIdQuery { Id = id }));

        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerCommand createCustomer) => Ok(await Mediator.Send(createCustomer));

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCustomerCommand updateCustomer)
        {
            await Mediator.Publish(updateCustomer);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await Mediator.Publish(new DeleteCustomerCommand { Id = id });
            return NoContent();
        }
    }
}