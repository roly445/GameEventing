using GameEventing.GameEvents.EventData;

namespace GameEventing.GameEvents.Events
{
    public class ArmourAssignedEvent : IGameEvent<ArmourAssignedEventData>
    {
        public ArmourAssignedEvent(Game game, ArmourAssignedEventData data)
        {
            this.Game = game;
            this.Data = data;
        }

        public Game Game { get; }
        public ArmourAssignedEventData Data { get; }
    }
}