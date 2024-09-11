using GestionDeStock.Application.Common;
using GestionDeStock.Domain.Dtos.Response;
using GestionDeStock.Domain.Entities;
using MediatR;

namespace GestionDeStock.Application.Command.Create
{
    public class CreateStockCommand : IRequest<StockResponse>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }

        public double Price { get; set; }

        public string? Category { get; set; }
    }

    public class CreateStockCommandHandler : IRequestHandler<CreateStockCommand, StockResponse>
    {
        private readonly IStockManagementRepository _repository;

        public CreateStockCommandHandler(IStockManagementRepository repository)
        {
            _repository = repository;
        }

        public async Task<StockResponse> Handle(CreateStockCommand request, CancellationToken cancellationToken)
        {
            var stock = new StockEntity
            {
                Name = request.Name,
                Description = request.Description,
                Quantity = request.Quantity,
                Price = request.Price,
                LoadDate = DateTime.Now,
                Category = new CategoryEntity { Id = 1, Name = request.Category }

            };

            var id = _repository.CreateStock(stock);
            return new StockResponse { Message = "Stock creado con éxito.", StockId = await id };
        }
    }
}
