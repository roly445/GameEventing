using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GameEventing.GameEvents.Events;
using MediatR;

namespace GameEventing.GameEvents.Handlers
{
    public class ArmourAssignedEventHandler : IRequestHandler<ArmourAssignedEvent>
    {
        public Task Handle(ArmourAssignedEvent message, CancellationToken cancellationToken)
        {
            var character = message.Game.Characters.First(x => x.Id == message.Data.CharacterId);
            var armour = character.Inventory.First(x => x.Id == message.Data.ArmourId);
            character.AssignArmour(armour);
            return Task.CompletedTask;
        }
    }
}