using GameEventing.GameEvents.EventData;

namespace GameEventing.GameEvents.Events
{
    public class WeaponDroppedEvent : IGameEvent<WeaponDroppedEventData>
    {
        public WeaponDroppedEvent(Game game, WeaponDroppedEventData data)
        {
            this.Game = game;
            this.Data = data;
        }

        public Game Game { get; }
        public WeaponDroppedEventData Data { get; }
    }
}