using System;
using System.IO;
using Newtonsoft.Json;

namespace Restfulie.Server.Unmarshalling.Deserializers.Json
{
    public class JsonDeserializer : IResourceDeserializer
    {
        public object Deserialize(string content, Type objectType)
        {
            using (var jsonReader = new StringReader(content))
            {
                var deserializer = new JsonSerializer();

                return deserializer.Deserialize(new JsonTextReader(jsonReader), objectType);
            }
        }
    }
}
