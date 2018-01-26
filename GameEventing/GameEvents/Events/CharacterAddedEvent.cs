using GameEventing.GameEvents.EventData;

namespace GameEventing.GameEvents.Events
{
    public class CharacterAddedEvent : IGameEvent<CharacterAddedEventData>
    {
        public CharacterAddedEvent(Game game, CharacterAddedEventData data)
        {
            this.Game = game;
            this.Data = data;
        }

        public Game Game { get; }
        public CharacterAddedEventData Data { get; }
    }
}
