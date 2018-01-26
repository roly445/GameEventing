using System;

namespace GameEventing.GameObjects
{
    public interface IGameObject
    {
        Guid Id { get; }

        string Name { get; }
    }
}