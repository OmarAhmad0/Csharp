using api.Extensions;
using api.Interfaces;
using api.Models;
using api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/Profolio")]
    [ApiController]
    public class ProfolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IStockrepository _stockrepository;

        private readonly IProfolioRepository _profolioRepository;
        private readonly IFMPService _fMPService;
        public ProfolioController(UserManager<AppUser> userManager, IStockrepository stockrepository , IProfolioRepository profolioRepository, IFMPService fMPService)
        {
            _userManager = userManager;
            _stockrepository = stockrepository;
            _profolioRepository = profolioRepository;
            _fMPService = fMPService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserProtfolios()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userPortfolio = await _profolioRepository.GetUserPortfolio(appUser);

            return Ok(userPortfolio);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPortfolio(string symbol)
        {

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var stock = await _stockrepository.GetBySymbolAsync(symbol);


            if (stock == null)
            {
                stock = await _fMPService.FindStockBySymbleAsync(symbol);
                if (stock == null)
                    return BadRequest("This stock dose not exists");
                else
                {
                    await _stockrepository.CreateStockAsync(stock);
                }

            }
            if(stock == null )
                return BadRequest("This stock dose not exists");

            var userPortfolio = await _profolioRepository.GetUserPortfolio(appUser);

            if (userPortfolio.Any(e => e.Symbol.ToLower() == symbol.ToLower()))
                return BadRequest("Cannot add same stock");

            var portfolioModel = new Portfolio
            {
                StockId = stock.StockId,
                AppUserId = appUser.Id,
            };
            await _profolioRepository.CreateAsync(portfolioModel);

            if (portfolioModel == null)
                return StatusCode(500, "Could not create");

            return Created();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeletePortfolio(string symbol)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var stock = await _stockrepository.GetBySymbolAsync(symbol);

            if (stock == null)
                return BadRequest("Stock not found");

            var userPortfolio = await _profolioRepository.GetUserPortfolio(appUser);

            var filteredStock = userPortfolio.Where((e => e.Symbol.ToLower() == symbol.ToLower()));

            if (filteredStock.Count() == 1)
                await _profolioRepository.DeleteAsync(appUser, symbol);
            else
                return BadRequest("Stock not in your portfolio");
            return Ok("Stock Deleted");
        }
    }
}
