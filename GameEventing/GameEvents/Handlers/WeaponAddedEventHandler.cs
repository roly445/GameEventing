using System.Threading;
using System.Threading.Tasks;
using GameEventing.GameEvents.Events;
using GameEventing.GameObjects.Items;
using MediatR;

namespace GameEventing.GameEvents.Handlers
{
    public class WeaponAddedEventHandler : IRequestHandler<WeaponAddedEvent>
    {
        public Task Handle(WeaponAddedEvent message, CancellationToken cancellationToken)
        {
            message.Game.AddItem(new Weapon(message.Data.Id, message.Data.Name, message.Data.Cost, message.Data.Weight,
                message.Data.Damage, message.Data.X, message.Data.Y));
            return Task.CompletedTask;
        }
    }
}