using System;
using Newtonsoft.Json.Linq;

namespace GameEventing.GameEvents.EventData
{
    public class ArmourDroppedEventData : IEventData
    {
        public readonly Guid CharacterId;
        public readonly Guid ItemId;

        public ArmourDroppedEventData(Guid characterId, Guid itemId)
        {
            this.CharacterId = characterId;
            this.ItemId = itemId;
        }
    }
}