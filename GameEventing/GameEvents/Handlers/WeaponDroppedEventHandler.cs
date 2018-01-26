using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GameEventing.GameEvents.Events;
using MediatR;

namespace GameEventing.GameEvents.Handlers
{
    public class WeaponDroppedEventHandler : IRequestHandler<WeaponDroppedEvent>
    {
        public Task Handle(WeaponDroppedEvent message, CancellationToken cancellationToken)
        {
            var character = message.Game.Characters.First(x => x.Id == message.Data.CharacterId);
            var item = message.Game.Items.First(x => x.Id == message.Data.ItemId);
            character.DropItemFromInventory(item);
            return Task.CompletedTask;
        }
    }
}