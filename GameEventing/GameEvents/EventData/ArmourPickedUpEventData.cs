using System;

namespace GameEventing.GameEvents.EventData
{
    public class ArmourPickedUpEventData : IEventData
    {
        public readonly Guid CharacterId;
        public readonly Guid ItemId;

        public ArmourPickedUpEventData(Guid characterId, Guid itemId)
        {
            this.CharacterId = characterId;
            this.ItemId = itemId;
        }
    }
}