using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GameEventing.GameEvents.Events;
using MediatR;

namespace GameEventing.GameEvents.Handlers
{
    public class ArmourDroppedEventHandler : IRequestHandler<ArmourDroppedEvent>
    {
        public Task Handle(ArmourDroppedEvent message, CancellationToken cancellationToken)
        {
            var character = message.Game.Characters.First(x => x.Id == message.Data.CharacterId);
            var item = message.Game.Items.First(x => x.Id == message.Data.ItemId);
            character.DropItemFromInventory(item);
            return Task.CompletedTask;
        }
    }
}