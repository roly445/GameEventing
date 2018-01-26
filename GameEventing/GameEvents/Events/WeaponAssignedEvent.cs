using GameEventing.GameEvents.EventData;

namespace GameEventing.GameEvents.Events
{
    public class WeaponAssignedEvent : IGameEvent<WeaponAssignedEventData>
    {
        public WeaponAssignedEvent(Game game, WeaponAssignedEventData data)
        {
            this.Game = game;
            this.Data = data;
        }

        public Game Game { get; }
        public WeaponAssignedEventData Data { get; }
    }
}