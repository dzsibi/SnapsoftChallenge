using Newtonsoft.Json;

namespace Barrel.Model
{
    class Input
    {
        [JsonProperty("barrelEthanolPairs")]
        public int[][] BarrelEthanolPairs { get; set; }
    }
}
