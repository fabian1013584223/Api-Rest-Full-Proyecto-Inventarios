using Microsoft.AspNetCore.Mvc;
using Proyect.Presentation.ModelBinders;
using Service.Contracts;
using Shared.DataTransferObjects;


namespace StockProductos.Presentation.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IServiceManager _service;

        public StockController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllStocksAsync()
        {
            var stocks = await _service.StockService.GetAllStocksAsync(trackChanges: false);

            return Ok(stocks);
        }

        [HttpGet("{stockId:guid}", Name = "StockById")]
        public async Task<IActionResult> GetStockByIdAsync(Guid stockId)
        {
            var stock = await _service.StockService.GetStockByIdAsync(stockId, trackChanges: false);
            return Ok(stock);
        }

        [HttpGet("collection/({ids})", Name = "StockCollection")]
        public async Task<IActionResult> GetStockCollectionAsync([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var stocks = await _service.StockService.GetByIdsAsync(ids, trackChanges: false);

            return Ok(stocks);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStockAsync([FromBody] StockForCreationDTO stock)
        {
            if (stock is null)
                return BadRequest("StockForCreationDto object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            ModelState.ClearValidationState(nameof(StockForCreationDTO));

            var createdStock = await _service.StockService.CreateStockAsync(stock);
            return CreatedAtRoute("StockById", new { stockId = createdStock.StockId }, createdStock);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateStockCollectionAsync([FromBody] IEnumerable<StockForCreationDTO> stockCollection)
        {
            var result = await _service.StockService.CreateStockCollectionAsync(stockCollection);

            return CreatedAtRoute("StockCollection", new { result.ids }, result.stocks);
        }

        [HttpDelete("{stockId:guid}")]
        public async Task<IActionResult> DeleteStockAsync(Guid stockId)
        {
            await _service.StockService.DeleteStockAsync(stockId, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{stockId:guid}")]
        public async Task<IActionResult> UpdateStockAsync(Guid stockId, [FromBody] StockForUpdateDTO stock)
        {
            if (stock is null)
                return BadRequest("StockForUpdateDto object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.StockService.UpdateStockAsync(stockId, stock, trackChanges: true);
            return NoContent();
        }
    }
}


      
