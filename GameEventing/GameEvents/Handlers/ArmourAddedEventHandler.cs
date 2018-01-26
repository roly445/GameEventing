using System.Threading;
using System.Threading.Tasks;
using GameEventing.GameEvents.EventData;
using GameEventing.GameEvents.Events;
using GameEventing.GameObjects.Items;
using MediatR;

namespace GameEventing.GameEvents.Handlers
{
    public class ArmourAddedEventHandler : IRequestHandler<ArmourAddedEvent>
    {
        public Task Handle(ArmourAddedEvent message, CancellationToken cancellationToken)
        {
            message.Game.AddItem(new Armour(message.Data.Id, message.Data.Name, message.Data.Cost, message.Data.Weight,
                message.Data.Resistance,  message.Data.X, message.Data.Y));
            return Task.CompletedTask;
        }
    }
}