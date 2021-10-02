using Newtonsoft.Json;

namespace Framework.Model
{
    public class StartSubmissionRequest
    {
        [JsonProperty("problem")]
        public string ProblemId { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? SampleIndex { get; set; }
    }
}
