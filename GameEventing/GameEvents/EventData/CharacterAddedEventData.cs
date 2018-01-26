using System;
using Newtonsoft.Json.Linq;

namespace GameEventing.GameEvents.EventData
{
    public class CharacterAddedEventData : IEventData
    {
        public readonly string Name;
        public readonly int ActionPoints;
        public readonly int HitPoints;
        public readonly Guid Id;

        public CharacterAddedEventData(Guid id, string name, int actionPoints, int hitPoints, int x, int y)
        {
            this.Name = name;
            this.ActionPoints = actionPoints;
            this.HitPoints = hitPoints;
            this.X = x;
            this.Y = y;
            this.Id = id;
        }

        public readonly int X;
        public readonly int Y;
    }
}