using CepediFullStack.Application.Dtos;
using CepediFullStack.Application.Dtos.Product;
using CepediFullStack.Application.Validators;
using CepediFullStack.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CepediFullStack.Presentation.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService) =>
            _productService = productService;

        [HttpGet(Name = "GetProducts")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> Get()
        {
            var products = await _productService.GetAllAsync<ProductResponse>();
            if (products is null || !products.Any()) return NotFound(); 
            
            return Ok(products);                   
        }

        [HttpGet("{id}", Name = "GetProduct") ]
        public async Task<ActionResult<ProductResponse>> Get(Guid id)
        {
           var product =  await _productService.GetByIdAsync<ProductResponse>(id);
           if(product is null) return NotFound();

           return Ok(product);        
        }

        [HttpPost(Name = "CreateProduct")]
        public async Task<ActionResult<ProductResponse>> Create(ProductRequest request)
        {
            var results = Validator.Validate(new ProductValidator(), request);
            if(!results.IsValid) return BadRequest(results.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));

            var createdProduct = await _productService.CreateAsync<ProductRequest, ProductResponse>(request);
            
            return CreatedAtAction(nameof(Get), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}", Name = "UpdateProduct")]
        public async Task<IActionResult> Update(Guid id, ProductRequest request)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product is null) return NotFound();
            
            await _productService.UpdateAsync(id, request);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);
            if(product is null) return NotFound();

            await _productService.DeleteAsync(product);

            return NoContent();
        }
    }
}
