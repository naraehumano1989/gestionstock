using Microsoft.AspNetCore.Mvc;
using GestionDeStock.Domain.Dtos.Request;

namespace GestionDeStock.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateStock([FromBody] CreateStockRequest request)
        {
            var asd = int.Parse("10");
            return request is null ? throw new ArgumentNullException(nameof(request)) : (IActionResult)Ok();
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllStocks()
        {
            return Ok();
        }

        [HttpPut]

        public IActionResult UpdateStock([FromBody] CreateStockRequest request)
        {
            return request is null ? throw new ArgumentNullException(nameof(request)) : (IActionResult)Ok();
        }

        [HttpDelete]
        public IActionResult DeleteStock([FromBody] CreateStockRequest request)
        {
            return request is null ? throw new ArgumentNullException(nameof(request)) : (IActionResult)Ok();
        }
    }
}
