using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GameEventing.GameEvents.Events;
using MediatR;

namespace GameEventing.GameEvents.Handlers
{
    public class MoveCharacterEventHandler : IRequestHandler<MoveCharacterEvent>
    {
        public Task Handle(MoveCharacterEvent message, CancellationToken cancellationToken)
        {
            var character = message.Game.Characters.First(x => x.Id == message.Data.CharacterId);
            character.Move(message.Data.X, message.Data.Y);
            return Task.CompletedTask;
        }
    }
}