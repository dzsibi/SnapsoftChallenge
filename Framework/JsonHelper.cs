using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Framework
{
    static class JsonHelper
    {
        public static readonly Encoding DefaultEncoding = new UTF8Encoding(false);

        public static readonly JsonSerializer Serializer = JsonSerializer.CreateDefault(new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Error,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        });

        public static T Deserialize<T>(Stream stream)
        {
            using var textReader = new StreamReader(stream, encoding: DefaultEncoding);
            using var jsonReader = new JsonTextReader(textReader);
            return Serializer.Deserialize<T>(jsonReader);
        }

        public static void Serialize<T>(Stream stream, T obj)
        {
            using var textWriter = new StreamWriter(stream, encoding: DefaultEncoding, leaveOpen: true);
            using var jsonWriter = new JsonTextWriter(textWriter);
            Serializer.Serialize(jsonWriter, obj);
        }
    }
}
