using CepediFullStack.Application.Dtos;
using CepediFullStack.Application.Dtos.Order;
using CepediFullStack.Application.Validators;
using CepediFullStack.Domain.Interfaces;
using CepediFullStack.Infrastructure.Repositories;
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
        private readonly IProductService _productService;

        public OrdersController(
            IOrderService orderService, 
            IStatusService statusService,
            IProductService productService
        ) 
        {
            _orderService = orderService;
            _statusService = statusService;
            _productService = productService;
        }

        [HttpGet(Name = "GetOrders")]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> Get()
        {
            var orders = await _orderService.GetAllWithIncludesAsync<OrderResponse>();
            if (orders is null || !orders.Any()) return NotFound("Orders not found."); 
            
            return Ok(orders);                   
        }

        [HttpGet("{id}", Name = "GetOrder") ]
        public async Task<ActionResult<OrderResponse>> Get(Guid id)
        {
           var order =  await _orderService.GetByIdWithIncludesAsync<OrderResponse>(id);
           if(order is null) return NotFound($"Order with {id} not found.");

           return Ok(order);        
        }

        [HttpGet("{orderId}/Products", Name = "GetOrderProducts")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetOrderProducts(Guid orderId)
        {
            var order = await _orderService.GetByIdAsync(orderId);
            if (order is null) return NotFound("Order not found.");

            var products = await _orderService.GetProductsAsync<ProductResponse>(orderId);
            return Ok(products);
        }

        [HttpGet("{orderId}/Products/{productId}", Name = "GetOrderProduct")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetOrderProduct(Guid orderId, Guid productId)
        {
            var order = await _orderService.GetByIdAsync(orderId);
            if (order is null) return NotFound("Order not found.");

            var products = await _orderService.GetProductsAsync<ProductResponse>(orderId);
            return Ok(products);
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

        [HttpPost("{orderId}/Products/{productId}", Name = "AddProductToOrder")]
        public async Task<IActionResult> AddProductToOrder(Guid orderId, Guid productId)
        {
            var order = await _orderService.GetByIdAsync(orderId);
            if (order is null) return NotFound("Order not found.");

            var product = await _productService.GetByIdAsync(productId);
            if (product is null) return NotFound("Product not found.");

            await _orderService.AddOrderProductAsync(orderId, productId);

            return NoContent();
        }

        [HttpPut("{id}", Name = "UpdateOrder")]
        public async Task<IActionResult> Update(Guid id, OrderRequest request)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order is null) return NotFound("Order not found.");
            
            await _orderService.UpdateAsync(id, request);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if(order is null) return NotFound("Order not found.");

            await _orderService.DeleteAsync(order);

            return NoContent();
        }

        [HttpDelete("{orderId}/Products/{productId}", Name = "RemoveProductFromOrder")]
        public async Task<IActionResult> RemoveProductFromOrder(Guid orderId, Guid productId)
        {
            var order = await _orderService.GetByIdAsync(orderId);
            if (order is null) return NotFound("Order not found.");

            var product = await _productService.GetByIdAsync(productId);
            if (product is null) return NotFound("Product not found.");

            await _orderService.RemoveOrderProductAsync(orderId, productId);

            return NoContent();
        }
    }
}
