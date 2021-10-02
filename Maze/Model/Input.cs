using Newtonsoft.Json;

namespace Maze.Model
{
    class Input
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public int[] Maze { get; set; }

        [JsonProperty("startCell")]
        public Point StartCell { get; set; }

        [JsonProperty("endCell")]
        public Point EndCell { get; set; }
    }
}
