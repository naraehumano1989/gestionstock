using GestionDeStock.Application.Common;
using GestionDeStock.Domain.Entities;
using GestionDeStock.Infrastructure.Persistence;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeStock.Infrastructure.Services
{
    public class StockManagementRepository : IStockManagementRepository
    {
        private readonly AppDbContext _context;

        public StockManagementRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<int> CreateStock(StockEntity stock)
        {
           var result = await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public Task<int> DeleteStock(int stockId)
        {
            var stock = _context.Stocks.FirstOrDefault(s => s.Id == stockId);
            if (stock != null)
            {
                _context.Stocks.Remove(stock);
                return _context.SaveChangesAsync();
            }

            return Task.FromResult(stockId);
        }

        public Task<IEnumerable<StockEntity>> GetAllStocks()
        {
            var stocks = _context.Stocks.ToList();
            return Task.FromResult(stocks.AsEnumerable());
        }

        public Task<int> UpdateStock(StockEntity stock)
        {
            var existingStock = _context.Stocks.FirstOrDefault(s => s.Id == stock.Id);
            if (existingStock != null)
            {
                existingStock.Name = stock.Name;
                existingStock.Description = stock.Description;
                existingStock.Price = stock.Price;
                existingStock.LoadDate = stock.LoadDate;
                existingStock.Category = stock.Category;
                return _context.SaveChangesAsync();
            }
            return Task.FromResult(stock.Id);
        }
    }
}
