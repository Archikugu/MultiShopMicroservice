using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Commands
{
    public class RemoveOrderingCommand : IRequest
    {
        public int ID { get; set; }

        public RemoveOrderingCommand(int id)
        {
            ID = id;
        }
    }
}
