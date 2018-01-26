using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEventing.GameEvents.EventData;

namespace GameEventing.GameEvents.Events
{
    public class WeaponAddedEvent : IGameEvent<WeaponAddedEventData>
    {
        public WeaponAddedEvent(Game game, WeaponAddedEventData data)
        {
            this.Game = game;
            this.Data = data;
        }

        public Game Game { get; }
        public WeaponAddedEventData Data { get; }
    }
}
