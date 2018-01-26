using System;

namespace GameEventing.GameEvents.EventData
{
    public class ArmourAddedEventData : IEventData
    {
        public readonly float Weight;
        public readonly Guid Id;
        public readonly string Name;
        public readonly float Cost;
        public readonly int Resistance;
        public readonly int X;
        public readonly int Y;

        public ArmourAddedEventData(Guid id, string name, float weight, float cost, int resistance, int x, int y)
        {
            this.Weight = weight;
            this.Id = id;
            this.Name = name;
            this.Cost = cost;
            this.Resistance = resistance;
            this.X = x;
            this.Y = y;
        }
    }
}