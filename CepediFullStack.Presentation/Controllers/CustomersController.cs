using CepediFullStack.Application.Dtos.Customer;
using CepediFullStack.Application.Validators;
using CepediFullStack.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CepediFullStack.Presentation.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController (ICustomerService customerService) =>
            _customerService = customerService;

        [HttpGet(Name = "GetCustomers")]
        public async Task<ActionResult<IEnumerable<CustomerResponse>>> Get()
        {
            var customers = await _customerService.GetAllAsync<CustomerResponse>();
            if (customers is null || !customers.Any()) return NotFound(); 
            
            return Ok(customers);                   
        }

        [HttpGet("{id}", Name = "GetCustomer") ]
        public async Task<ActionResult<CustomerResponse>> Get(Guid id)
        {
           var customer =  await _customerService.GetByIdAsync<CustomerResponse>(id);
           if(customer is null) return NotFound();

           return Ok(customer);        
        }

        [HttpPost(Name = "CreateCustomer")]
        public async Task<ActionResult<CustomerResponse>> Create(CustomerRequest request)
        {
            var results = Validator.Validate(new CustomerValidator(), request);
            if(!results.IsValid) return BadRequest(results.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));

            var createdCustomer = await _customerService.CreateAsync<CustomerRequest, CustomerResponse>(request);
            
            return CreatedAtAction(nameof(Get), new { id = createdCustomer.Id }, createdCustomer);
        }

        [HttpPut("{id}", Name = "UpdateCustomer")]
        public async Task<IActionResult> Update(Guid id, CustomerRequest request)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer is null) return NotFound();
            
            await _customerService.UpdateAsync(id, request);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteCustomer")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if(customer is null) return NotFound();

            await _customerService.DeleteAsync(customer);

            return NoContent();
        }
    }
}
