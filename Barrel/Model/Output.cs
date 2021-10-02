using Newtonsoft.Json;

namespace Barrel.Model
{
    class Output
    {
        [JsonProperty("barrelSequence")]
        public int[] BarrelSequence { get; set; }
    }
}
