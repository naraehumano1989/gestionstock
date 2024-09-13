using GestionDeStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
