using GestionDeStock.Application.Common;
using GestionDeStock.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeStock.Application.Command.Update
{
    public class UpdateStockCommand : IRequest<int>
    {
        public StockEntity Stock { get; set; }
    }

    public class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommand, int>
    {
        private readonly IStockManagementRepository _stockManagementRepository;

        public UpdateStockCommandHandler(IStockManagementRepository stockManagementRepository)
        {
            _stockManagementRepository = stockManagementRepository;
        }

        public async Task<int> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            return await _stockManagementRepository.UpdateStock(request.Stock);
        }
    }
}
