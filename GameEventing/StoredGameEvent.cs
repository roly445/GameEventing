using GameEventing.GameEvents;
using MediatR;

namespace GameEventing
{
    public class StoredGameEvent
    {
        public StoredGameEvent(string description, string gameEventName, IEventData gameEventData)
        {
            this.Description = description;
            this.GameEventName = gameEventName;
            this.GameEventData = gameEventData;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
        public string GameEventName { get; private set; }

        public IEventData GameEventData { get; private set; }
    }
}