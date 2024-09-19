using api.Data;
using api.DTOs.Stock;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockrepository
    {
        private readonly AppDbContext _context;

        public StockRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateStockAsync(Stock StockModel)
        {

            await _context.Stocks.AddAsync(StockModel);

            await _context.SaveChangesAsync();

            return StockModel;
        }

        public async Task<Stock?> DeleteStockAsync(int Id)
        {
            var StockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.StockId == Id);

            if (StockModel == null)
                return null;

            _context.Stocks.Remove(StockModel);

            await _context.SaveChangesAsync();

            return StockModel;
        }

        public async Task<Stock?> GetBySymbolAsync(string Symbol)
        {
            return await _context.Stocks.FirstOrDefaultAsync(s => s.Symbol == Symbol);
        }

        public async Task<Stock?> GetStockByIdAsync(int Id)
        {
            return await _context.Stocks.Include(c => c.Comments).ThenInclude(a => a.AppUser).FirstOrDefaultAsync(x=>x.StockId==Id);
        }

        public async Task<List<Stock>> GetStocksAsync(QueryObject Query)
        {
            var Stocks =  _context.Stocks.Include(c=>c.Comments).ThenInclude(a => a.AppUser).AsQueryable();
            if (!string.IsNullOrWhiteSpace(Query.CompanyName))
                Stocks = Stocks.Where(s => s.CompanyName.Contains(Query.CompanyName));

            if (!string.IsNullOrWhiteSpace(Query.Symbol))
                Stocks = Stocks.Where(s => s.Symbol.Contains(Query.Symbol));

            if (!string.IsNullOrWhiteSpace(Query.SortBy))
            {
                if (Query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    Stocks = Query.IsDecsending ?
                        Stocks.OrderByDescending(s => s.Symbol) 
                        : Stocks.OrderBy(s => s.Symbol);
                }
            }
            var SkipNumber = (Query.PageNumber - 1) * Query.PageSize;

            return await Stocks.Skip(SkipNumber).Take(Query.PageSize).ToListAsync();
        }

        public async Task<bool> StockExists(int Id)
        {
          return  await _context.Stocks.AnyAsync(x => x.StockId == Id);
        }

        public async Task<Stock?> UpdateStockAsync(int Id, UpdateStockDTO StockModel)
        {
            var ExistingStock = await _context.Stocks.FirstOrDefaultAsync(x => x.StockId == Id);

            if (ExistingStock == null)
                return null;


            ExistingStock.Symbol = StockModel.Symbol;
            ExistingStock.CompanyName = StockModel.CompanyName;
            ExistingStock.Purchase = StockModel.Purchase;
            ExistingStock.LastDiv = StockModel.LastDiv;
            ExistingStock.Industry = StockModel.Industry;
            ExistingStock.MarketCap = StockModel.MarketCap;

            await _context.SaveChangesAsync();

            return ExistingStock;
        }
    }
}
