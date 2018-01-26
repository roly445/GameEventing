using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GameEventing.GameEvents.Events;
using MediatR;

namespace GameEventing.GameEvents.Handlers
{
    public class WeaponAssignedEventHandler : IRequestHandler<WeaponAssignedEvent>
    {
        public Task Handle(WeaponAssignedEvent message, CancellationToken cancellationToken)
        {
            var character = message.Game.Characters.First(x => x.Id == message.Data.CharacterId);
            var weapon = character.Inventory.First(x => x.Id == message.Data.WeaponId);
            character.AssignWeapon(weapon);
            return Task.CompletedTask;
        }
    }
}