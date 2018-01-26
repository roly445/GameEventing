using System;
using System.Collections.Generic;
using GameEventing.Components;
using GameEventing.GameObjects.Items;

namespace GameEventing.GameObjects
{
    public class Character : IGameObject
    {
        private readonly List<IItem> _inventory;

        public Character(Guid id, string name, int hitPoints, int actionPoints, int x, int y)
        {
            this._inventory = new List<IItem>();
            this.Id = id;
            this.Name = name;
            this.HitPoints = hitPoints;
            this.ActionPoints = actionPoints;
            this.Position = new Point(x, y);
        }

        public int HitPoints { get; private set; }
        public int ActionPoints { get; private set; }

        public Weapon Weapon { get; private set; }
        public Armour Armour { get; private set; }

        public IReadOnlyList<IItem> Inventory => this._inventory;

        public Guid Id { get; }
        public string Name { get; }
        public Point Position { get; private set; }

        public void AddItemToInventory(IItem item)
        {
            item.PickedUp(this);
            this._inventory.Add(item);
        }

        public void DropItemFromInventory(IItem item)
        {
            item.Dropped();
            this._inventory.Remove(item);
        }

        public bool AssignWeapon(IItem item)
        {
            if (!this._inventory.Contains(item))
            {
                return false;
            }

            if (!(item is Weapon weapon))
            {
                return false;
            }

            this._inventory.Remove(item);
            this.Weapon = weapon;
            return true;
        }

        public bool AssignArmour(IItem item)
        {
            if (!this._inventory.Contains(item))
            {
                return false;
            }

            if (!(item is Armour armour))
            {
                return false;
            }

            this._inventory.Remove(item);
            this.Armour = armour;
            return true;
        }

        public int AddHitPointsAndReturnValue(int hitPoints)
        {
            this.HitPoints += hitPoints;
            return this.HitPoints;
        }

        public int AddActionPointsAndReturnValue(int actionPoints)
        {
            this.ActionPoints += actionPoints;
            return this.ActionPoints;
        }

        public void Move(int x, int y)
        {
            this.Position = new Point(x,  y);
        }
    }
}