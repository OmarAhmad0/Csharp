using api.DTOs.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IStockrepository
    {
        Task<List<Stock>> GetStocksAsync(QueryObject Query);
        Task<Stock?> GetStockByIdAsync(int Id);

        Task<Stock?> GetBySymbolAsync(string Symbol);
        Task<Stock> CreateStockAsync(Stock StockModel);
        Task<Stock?> UpdateStockAsync(int Id , UpdateStockDTO StockModel);
        Task<Stock?> DeleteStockAsync(int Id);

        Task<bool> StockExists(int Id);
    }
}
