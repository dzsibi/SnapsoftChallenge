using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Framework.Model
{
    public class Submission
    {
        public string Id { get; set; }

        public int TestCount { get; set; }

        public int? SampleIndex { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTimeOffset StartedAt { get; set; }
    }
}
