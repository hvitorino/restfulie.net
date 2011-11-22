using System.IO;
using Newtonsoft.Json;

namespace Restfulie.Server.Marshalling.Serializers.Json
{
    public class JsonSerializer : IResourceSerializer
    {
        public string Serialize(object resource)
        {
            using (var jsonWriter = new StringWriter())
            {
                var serializer = new Newtonsoft.Json.JsonSerializer
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                serializer.Serialize(new JsonTextWriter(jsonWriter), resource);

                return jsonWriter.GetStringBuilder().ToString();
            }
        }
    }
}
