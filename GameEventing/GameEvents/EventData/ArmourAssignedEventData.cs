using System;
using Newtonsoft.Json.Linq;

namespace GameEventing.GameEvents.EventData
{
    public class ArmourAssignedEventData : IEventData
    {
        public Guid CharacterId { get; set; }
        public Guid ArmourId { get; set; }
    }
}