using System;
using GameEventing.Components;

namespace GameEventing.GameObjects.Items
{
    public class Item : IItem
    {
        public Item(Guid id, string name, float cost, float weight, int x, int y)
        {
            this.Id = id;
            this.Name = name;
            this.Cost = cost;
            this.Weight = weight;
            this.Position = new Point(x, y);
        }

        public Guid Id { get; }
        public string Name { get; }
        public float Cost { get; }
        public float Weight { get; }
        public Point Position { get; private set; }
        public Character Owner { get; private set; }
        public bool IsOwned => this.Owner != null;

        public void PickedUp(Character owner)
        {
            if (this.Owner != null)
            {
                throw new Exception("Item Already Owned");
            }

            this.Owner = owner;
        }

        public void Dropped()
        {
            this.Position = this.Owner.Position;
            this.Owner = null;
        }
    }
}