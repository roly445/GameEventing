using GameEventing.GameEvents.EventData;

namespace GameEventing.GameEvents.Events
{
    public class ArmourPickedUpEvent : IGameEvent<ArmourPickedUpEventData>
    {
        public ArmourPickedUpEvent(Game game, ArmourPickedUpEventData data)
        {
            this.Game = game;
            this.Data = data;
        }

        public Game Game { get; }
        public ArmourPickedUpEventData Data { get; }
    }
}