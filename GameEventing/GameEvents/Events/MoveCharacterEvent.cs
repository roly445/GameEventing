using GameEventing.GameEvents.EventData;

namespace GameEventing.GameEvents.Events
{
    public class MoveCharacterEvent : IGameEvent<MoveCharacterEventData>
    {
        public MoveCharacterEvent(Game game, MoveCharacterEventData data)
        {
            this.Game = game;
            this.Data = data;
        }

        public Game Game { get; }
        public MoveCharacterEventData Data { get; }
    }
}