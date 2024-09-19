using api.Data;
using api.DTOs.Stock;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/Stock")]
    [ApiController]
    public class StockController : ControllerBase
    {

        private readonly IStockrepository _StockRepo;
       public StockController(IStockrepository StockRepo)
        {
            _StockRepo = StockRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAllStocks([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Stocks = await _StockRepo.GetStocksAsync(query);
            var StocksDto = Stocks.Select(s => s.ToStockDTO()).ToList();

            return Ok(StocksDto);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult> GetStockById([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Stock = await _StockRepo.GetStockByIdAsync(Id);

            if (Stock == null)
                return NotFound($"There is no Id = {Id} in Database");

            return Ok(Stock.ToStockDTO());
        }

        [HttpPost]
        public async Task<IActionResult> AddNewStock([FromBody] CreateStockDTO Stock)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var StockModel = Stock.ToStockCreateDTO();

            if (StockModel == null)
                return BadRequest();

            await _StockRepo.CreateStockAsync(StockModel);

            return NoContent();
        }

        [HttpPut("{Id:int}")]
        public async Task<IActionResult> UpdateStock([FromRoute] int Id, [FromBody] UpdateStockDTO UpdatedStock)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var StockModel = await _StockRepo.UpdateStockAsync(Id, UpdatedStock);

            if (StockModel == null)
                return NotFound($"There is no Id = {Id} in Database");

            return Ok(StockModel.ToStockDTO());
        }

        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> DeleteStock([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Stock = await _StockRepo.DeleteStockAsync(Id);
            if (Stock == null)
                return NotFound($"There is no Id = {Id} in Database");



            return NoContent();
        }
    }
}
