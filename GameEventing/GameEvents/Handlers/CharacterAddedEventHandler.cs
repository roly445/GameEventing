using System.Threading;
using System.Threading.Tasks;
using GameEventing.GameEvents.Events;
using MediatR;

namespace GameEventing.GameEvents.Handlers
{
    public class CharacterAddedEventHandler : IRequestHandler<CharacterAddedEvent>
    {
        public Task Handle(CharacterAddedEvent message, CancellationToken cancellationToken)
        {
            message.Game.AddCharacter(message.Data.Id, message.Data.Name, message.Data.HitPoints,
                message.Data.ActionPoints, message.Data.X, message.Data.Y);
            return Task.CompletedTask;
        }
    }
}