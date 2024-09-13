using Microsoft.AspNetCore.Mvc;
using MediatR;
using GestionDeStock.Application.Command.Create;
using GestionDeStock.Application.Queries;
using GestionDeStock.Application.Command.Update;
using GestionDeStock.Application.Command.Delete;
using Microsoft.AspNetCore.Authorization;

namespace GestionDeStock.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] CreateStockCommand registerStockCommand)
        {
            try
            {
                var stockId = await _mediator.Send(registerStockCommand);

                return Ok($"Stock registrado: {stockId}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("all")]
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns></returns>
        public async Task<IActionResult> GetAllStocks()
        {
           return Ok(await _mediator.Send(new GetAll()));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStock([FromBody] UpdateStockCommand request)
        {
           return Ok(await _mediator.Send(request));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStock(int stockId)
        {
           var stockToDelete = new DeleteStockCommand { StockId = stockId };
            return Ok(await _mediator.Send(stockToDelete));
        }
    }
}
