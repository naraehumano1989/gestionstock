using System.ComponentModel;

namespace GestionDeStock.Domain.Entities
{
    public class StockEntity
    {


        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime LoadDate { get; set; }

        public CategoryEntity Category { get; set; }

    }
}
