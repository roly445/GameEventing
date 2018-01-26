using System;
using Newtonsoft.Json.Linq;

namespace GameEventing.GameEvents.EventData
{
    public class WeaponAddedEventData : IEventData
    {
        public readonly Guid Id;
        public readonly string Name;
        public readonly float Cost;
        public readonly float Weight;
        public readonly int Damage;
        public readonly int X;
        public readonly int Y;

        public WeaponAddedEventData(Guid id, string name, float cost, float weight, int damage, int x, int y)
        {
            this.Id = id;
            this.Name = name;
            this.Cost = cost;
            this.Weight = weight;
            this.Damage = damage;
            this.X = x;
            this.Y = y;
        }
    }
}