using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace GameEventing
{
    public class StateSaver : IStateSaver
    {
        private readonly string _gameName;

        public StateSaver(string gameName)
        {
            this._gameName = gameName;
        }

        public void SaveEvent(StoredGameEvent storedGameEvent)
        {
            using (var db = new LiteDatabase(@"Save.db"))
            {
                var events = db.GetCollection<StoredGameEvent>(this._gameName);
                events.Insert(storedGameEvent);
            }
        }
    }

    public interface IStateSaver
    {
        void SaveEvent(StoredGameEvent storedGameEvent);
    }
}
