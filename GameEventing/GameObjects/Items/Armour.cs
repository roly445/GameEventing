using System;

namespace GameEventing.GameObjects.Items
{
    public class Armour : Item, IItem
    {
        public Armour(Guid id, string name, float cost, float weight, int resistance, int x, int y) : base(id, name, cost, weight, x,y)
        {
            this.Resistance = resistance;
        }


        public int Resistance { get; }
    }
}