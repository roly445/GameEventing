using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace GameEventing.GameEvents.EventData
{
    public class WeaponPickedUpEventData : IEventData
    {
        public readonly Guid CharacterId;
        public readonly Guid ItemId;

        public WeaponPickedUpEventData(Guid characterId, Guid itemId)
        {
            this.CharacterId = characterId;
            this.ItemId = itemId;
        }
    }

    public class WeaponPickedUpEvent : IGameEvent<WeaponPickedUpEventData>
    {
        public WeaponPickedUpEvent(Game game, WeaponPickedUpEventData data)
        {
            this.Game = game;
            this.Data = data;
        }

        public Game Game { get; }
        public WeaponPickedUpEventData Data { get; }
    }

    public class WeaponPickedUpEventHandler : IRequestHandler<WeaponPickedUpEvent>
    {
        public Task Handle(WeaponPickedUpEvent message, CancellationToken cancellationToken)
        {
            var character = message.Game.Characters.First(x => x.Id == message.Data.CharacterId);
            var item = message.Game.Items.First(x => x.Id == message.Data.ItemId);
            character.AddItemToInventory(item);
            return Task.CompletedTask;
        }
    }
}