using GestionDeStock.Application.Common;
using GestionDeStock.Domain.Entities;
using MediatR;

namespace GestionDeStock.Application.Command.Create
{
    public class CreateStockCommand : IRequest<int>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }

        public int Price { get; set; }

        public string? Category { get; set; }
    }

    public class CreateStockCommandHandler : IRequestHandler<CreateStockCommand, int>
    {
        private readonly IStockManagementRepository _repository;

        public CreateStockCommandHandler(IStockManagementRepository repository) => _repository = repository;

        public async Task<int> Handle(CreateStockCommand request, CancellationToken cancellationToken)
        {
            var stockEntity = new StockEntity
            {
                Name = request.Name,
                Quantity = request.Quantity,
                Price = request.Price,
                Description = request.Description,
                LoadDate = DateTime.Now,
                Category = request.Category
            };

            return await _repository.CreateStock(stockEntity);
        }
    }
}
