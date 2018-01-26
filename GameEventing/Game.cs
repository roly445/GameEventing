using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using GameEventing.GameEvents;
using GameEventing.GameObjects;
using GameEventing.GameObjects.Items;
using MediatR;

namespace GameEventing
{
    public class Game
    {
        private readonly IMediator _mediator;
        private readonly IStateSaver _stateSaver;
        private readonly List<Character> _characters;
        private readonly List<StoredGameEvent> _gameEvents;
        private readonly List<IItem> _items;
        public IReadOnlyList<Character> Characters => this._characters.AsReadOnly();
        public IReadOnlyList<IItem> Items => this._items;
        public IReadOnlyList<StoredGameEvent> GameEvents => this._gameEvents.AsReadOnly();

        public Game(IMediator mediator, IStateSaver stateSaver)
        {
            this._mediator = mediator;
            this._stateSaver = stateSaver;
            this._items = new List<IItem>();
            this._characters = new List<Character>();
            this._gameEvents = new List<StoredGameEvent>();
        }

        public Character AddCharacter(Guid id, string name, int hitPoints, int actionPoints,  int x, int y)
        {
            var character = new Character(id, name, hitPoints, actionPoints, x,y);
            this._characters.Add(character);
            return character;
        }

        public IItem AddItem(IItem item)
        {
            this._items.Add(item);
            return item;
        }


        public async Task<StoredGameEvent> AddGameEvent<TEventData>(string description, TEventData gameEventData) where TEventData : IEventData
        {
            var eventTypeDataName = gameEventData.GetType().Name;
            var eventTypeName = eventTypeDataName.Remove(eventTypeDataName.Length - 4);
            var eventType = typeof(IEventData).Assembly.GetTypes().First(x => x.Name == eventTypeName);
            var @event = (IRequest)Activator.CreateInstance(eventType, this, gameEventData);
            await _mediator.Send(@event);
            
            var storedGameEvent = new StoredGameEvent(description, eventTypeDataName, gameEventData);
            this._gameEvents.Add(storedGameEvent);
            this._stateSaver.SaveEvent(storedGameEvent);
            return storedGameEvent;
        }
    }
}