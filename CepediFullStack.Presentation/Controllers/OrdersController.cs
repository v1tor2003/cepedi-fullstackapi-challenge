using CepediFullStack.Application.Dtos.Order;
using CepediFullStack.Application.Validators;
using CepediFullStack.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CepediFullStack.Presentation.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IStatusService _statusService;

        public OrdersController(IOrderService orderService, IStatusService statusService) 
        {
            _orderService = orderService;
            _statusService = statusService;

        }

        [HttpGet(Name = "GetOrders")]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> Get()
        {
            var orders = await _orderService.GetAllAsync<OrderResponse>();
            if (orders is null || !orders.Any()) return NotFound(); 
            
            return Ok(orders);                   
        }

        [HttpGet("{id}", Name = "GetOrder") ]
        public async Task<ActionResult<OrderResponse>> Get(Guid id)
        {
           var order =  await _orderService.GetByIdAsync<OrderResponse>(id);
           if(order is null) return NotFound();

           return Ok(order);        
        }

        [HttpPost(Name = "CreateOrder")]
        public async Task<ActionResult<OrderResponse>> Create(OrderRequest request)
        {
            var results = Validator.Validate(new OrderValidator(), request);
            if(!results.IsValid) return BadRequest(results.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));

            var status = await _statusService.GetByIdAsync(request.StatusId);
            if(status is null) return BadRequest("Status.Id must be valid.");

            var createdOrder = await _orderService.CreateAsync<OrderRequest, OrderResponse>(request);
            
            return CreatedAtAction(nameof(Get), new { id = createdOrder.Id }, createdOrder);
        }

        [HttpPut("{id}", Name = "UpdateOrder")]
        public async Task<IActionResult> Update(Guid id, OrderRequest request)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order is null) return NotFound();
            
            await _orderService.UpdateAsync(id, request);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if(order is null) return NotFound();

            await _orderService.DeleteAsync(order);

            return NoContent();
        }
    }
}
