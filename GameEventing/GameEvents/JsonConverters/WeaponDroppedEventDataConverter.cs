using System;
using GameEventing.GameEvents.EventData;
using Newtonsoft.Json;

namespace GameEventing.GameEvents.JsonConverters
{
    public class WeaponDroppedEventDataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(WeaponDroppedEventData));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return null;
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}