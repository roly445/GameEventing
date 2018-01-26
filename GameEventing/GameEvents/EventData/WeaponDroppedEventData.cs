using System;

namespace GameEventing.GameEvents.EventData
{
    public class WeaponDroppedEventData : IEventData
    {
        public readonly Guid CharacterId;
        public readonly Guid ItemId;

        public WeaponDroppedEventData(Guid characterId, Guid itemId)
        {
            this.CharacterId = characterId;
            this.ItemId = itemId;
        }
    }
}