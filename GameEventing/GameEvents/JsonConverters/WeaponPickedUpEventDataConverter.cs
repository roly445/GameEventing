using System;
using GameEventing.GameEvents.EventData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GameEventing.GameEvents.JsonConverters
{
    public class WeaponPickedUpEventDataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(WeaponPickedUpEventData));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);

            var characterId = (Guid)jo["CharacterId"];
            var itemId = (Guid)jo["ItemId"];

            var eventData = new WeaponPickedUpEventData(characterId, itemId);
            return eventData;
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}