using GestionDeStock.Domain.Entities;

namespace GestionDeStock.Application.Common
{
    public interface IStockManagementRepository
    {
        Task<int> CreateStock(StockEntity stock);
        Task<int> UpdateStock(StockEntity stock);
        Task<int> DeleteStock(int stockId);
        Task<IEnumerable<StockEntity>> GetAllStocks();
    }
}
