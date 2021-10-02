using Newtonsoft.Json;

namespace Framework.Model
{
    public class StartTestRequest
    {
        [JsonProperty("submission")]
        public string SubmissionId { get; set; }
    }
}
