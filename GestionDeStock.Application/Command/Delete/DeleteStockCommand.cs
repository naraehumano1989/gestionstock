using MediatR;
using GestionDeStock.Domain.Dtos.Response;
namespace GestionDeStock.Application.Command.Delete
{
    public class DeleteStockCommand : IRequest<StockResponse>
    {
        public int StockId { get; set; }
    }

    public class DeleteStockCommandHandler(IStockServiceRepository repository) : IRequestHandler<DeleteStockCommand, StockResponse>
    {
        public async Task<StockResponse> Handle(DeleteStockCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
