using MediatR;
using GestionDeStock.Domain.Entities;
using GestionDeStock.Application.Common;

namespace GestionDeStock.Application.Queries
{
    public class GetAll : IRequest<IEnumerable<StockEntity>>
    {
    }

    public class GetAllHandler : IRequestHandler<GetAll, IEnumerable<StockEntity>>
    {
        private readonly IStockManagementRepository _stockManagementRepository;

        public GetAllHandler(IStockManagementRepository stockManagementRepository)
        {
            _stockManagementRepository = stockManagementRepository;
        }

        public async Task<IEnumerable<StockEntity>> Handle(GetAll request, CancellationToken cancellationToken)
        {
            return await _stockManagementRepository.GetAllStocks();
        }
    }
}
