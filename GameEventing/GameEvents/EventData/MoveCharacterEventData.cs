using System;
using Newtonsoft.Json.Linq;

namespace GameEventing.GameEvents.EventData
{
    public class MoveCharacterEventData : IEventData
    {
        public readonly Guid CharacterId;
        public readonly int X;
        public readonly int Y;

        public MoveCharacterEventData(Guid characterId, int x, int y)
        {
            this.CharacterId = characterId;
            this.X = x;
            this.Y = y;
        }
    }
}