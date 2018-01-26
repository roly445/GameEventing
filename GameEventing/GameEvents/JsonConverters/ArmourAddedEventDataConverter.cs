using System;
using GameEventing.GameEvents.EventData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GameEventing.GameEvents.JsonConverters
{
    public class ArmourAddedEventDataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(ArmourAddedEventData));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);

            var weight = (float)jo["Weight"];
            var itemId = (Guid)jo["Id"];
            var name = (string)jo["Name"];
            var cost = (float)jo["Cost"];
            var resistance = (int)jo["Resistance"];
            var x = (int)jo["X"];
            var y = (int)jo["Y"];

            var eventData = new ArmourAddedEventData(itemId, name,weight,cost,resistance,x,y);
            return eventData;
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}