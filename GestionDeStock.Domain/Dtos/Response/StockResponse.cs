using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeStock.Domain.Dtos.Response
{
    public class StockResponse
    {
        public string? Message { get; set; }
        public int StockId { get; set; }
    }
}
