using System;

namespace GameEventing.GameObjects.Items
{
    public class Weapon : Item, IItem
    {
        public Weapon(Guid id, string name, float cost, float weight, int damage, int x, int y) : base(id, name, cost,
            weight, x, y)
        {
            this.Damage = damage;
        }


        public int Damage { get; }
    }
}