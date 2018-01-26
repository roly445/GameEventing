using System;
using Newtonsoft.Json.Linq;

namespace GameEventing.GameEvents.EventData
{
    public class WeaponAssignedEventData : IEventData
    {
        public readonly Guid CharacterId;
        public readonly Guid WeaponId;

        public WeaponAssignedEventData(Guid characterId, Guid weaponId)
        {
            this.CharacterId = characterId;
            this.WeaponId = weaponId;
        }
    }
}