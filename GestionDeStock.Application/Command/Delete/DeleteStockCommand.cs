using GestionDeStock.Application.Common;
using MediatR;

namespace GestionDeStock.Application.Command.Delete
{
    public class DeleteStockCommand : IRequest<int>
    {
        public int StockId { get; set; }
    }

    public class DeleteStockCommandHandler : IRequestHandler<DeleteStockCommand, int>
    {

        private readonly IStockManagementRepository _repository;

        public DeleteStockCommandHandler(IStockManagementRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeleteStockCommand request, CancellationToken cancellationToken)
        {
            // Aquí va la lógica para eliminar el stock y retornar el resultado
            return await _repository.DeleteStock(request.StockId);
        }
    }
}
