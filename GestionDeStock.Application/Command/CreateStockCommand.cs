using MediatR;

namespace GestionDeStock.Application.Command
{
    public class CreateStockCommand :  IRequest<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }

    public class CreateStockCommandHandler : IRequestHandler<CreateStockCommand, string>
    {
        public async Task<string> Handle(CreateStockCommand request, CancellationToken cancellationToken)
        {
            return "Stock created successfully";
        }
    }
}
