using CommandLine;

namespace Framework.Model
{
    class Arguments
    {
        [Option("live", HelpText = "Run this solution as a live submission", Group = "Mode")]
        public bool Live { get; set; }

        [Option("sample", HelpText = "Use the specified sample index", Group = "Mode")]
        public int SampleIndex { get; set; }

        [Option("failed", HelpText = "Use the last failed test", Group = "Mode")]
        public bool Failed { get; set; }
    }
}
