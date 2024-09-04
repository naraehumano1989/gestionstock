using GestionDeStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeStock.Domain.Dtos.Request
{
    public class CreateStockRequest
    {
        public StockEntity Stock { get; set; }
    }
}
