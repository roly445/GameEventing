using GameEventing.GameEvents.EventData;

namespace GameEventing.GameEvents.Events
{
    public class ArmourDroppedEvent : IGameEvent<ArmourDroppedEventData>
    {
        public ArmourDroppedEvent(Game game, ArmourDroppedEventData data)
        {
            this.Game = game;
            this.Data = data;
        }

        public Game Game { get; }
        public ArmourDroppedEventData Data { get; }
    }
}