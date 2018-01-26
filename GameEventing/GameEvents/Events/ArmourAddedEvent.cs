using GameEventing.GameEvents.EventData;

namespace GameEventing.GameEvents.Events
{
    public class ArmourAddedEvent : IGameEvent<ArmourAddedEventData>
    {
        public ArmourAddedEvent(Game game, ArmourAddedEventData data)
        {
            this.Game = game;
            this.Data = data;
        }

        public Game Game { get; }
        public ArmourAddedEventData Data { get; }
    }
}