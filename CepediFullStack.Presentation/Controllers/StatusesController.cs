using CepediFullStack.Application.Dtos.Status;
using CepediFullStack.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CepediFullStack.Presentation.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusesController(IStatusService statusService) =>
            _statusService = statusService;

        [HttpGet(Name = "GetStatuses")]
        public async Task<ActionResult<IEnumerable<StatusResponse>>> Get()
        {
            var status = await _statusService.GetAllAsync<StatusResponse>();
            if (status is null || !status.Any()) return NotFound(); 
            
            return Ok(status);                   
        }

        [HttpGet("{id}", Name = "GetStatus") ]
        public async Task<ActionResult<StatusResponse>> Get(Guid id)
        {
           var status =  await _statusService.GetByIdAsync<StatusResponse>(id);
           if(status is null) return NotFound();

           return Ok(status);        
        }
    }
}
