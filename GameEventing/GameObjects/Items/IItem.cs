using GameEventing.Components;

namespace GameEventing.GameObjects.Items
{
    public interface IItem : IGameObject
    {
        float Cost { get; }
        float Weight { get; }
        Point Position { get; }

        Character Owner { get; }
        bool IsOwned { get; }

        void PickedUp(Character owner);
        void Dropped();
    }
}