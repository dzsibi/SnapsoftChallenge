using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Framework.Model
{
    public class StartTestResponse<T>
    {
        public string TestId { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTimeOffset Deadline { get; set; }

        public T Input { get; set; }
    }
}
