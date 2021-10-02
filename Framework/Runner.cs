using System;
using System.IO;
using System.Threading.Tasks;
using CommandLine;
using Framework.Model;

namespace Framework
{
    public abstract class Runner<TInput, TOutput>
    {
        public static readonly string FailedInputPath = "failed-input.json";

        public static readonly string FailedOutputPath = "failed-output.json";

        public static readonly string RetryOutputPath = "retry-output.json";

        public abstract string ProblemId { get; }

        public Task RunAsync(string[] args)
            => Parser.Default.ParseArguments<Arguments>(args).WithParsedAsync(RunAsync);

        private async Task RunAsync(Arguments arguments)
        {
            // Read API key from environment variable
            var apiKey = Environment.GetEnvironmentVariable("QPA_TOKEN");

            // Create client
            var client = new SubmissionClient(apiKey);

            // Check if we need to re-use the last captured message
            if (arguments.Failed)
            {
                if (File.Exists(FailedInputPath))
                {
                    using var inputStream = File.OpenRead(FailedInputPath);
                    var input = JsonHelper.Deserialize<TInput>(inputStream);
                    var output = await ExecuteTestAsync(input);
                    using var outputStream = File.Create(RetryOutputPath);
                    JsonHelper.Serialize(outputStream, output);
                    Console.WriteLine("Retry run complete, output was dumped");
                }
                else
                {
                    Console.WriteLine("Failed input file not found");
                }
            }
            else
            {
                // Start submission
                var response = await client.StartSubmissionAsync(ProblemId, arguments.Live ? null : arguments.SampleIndex);
                Console.WriteLine($"Submission started: {response.Submission.Id} ({response.Submission.TestCount} tests)");

                // Execute tests
                for (int i = 0; i < response.Submission.TestCount; ++i)
                {
                    var test = await client.StartTestAsync<TInput>(response.Submission.Id);
                    var output = await ExecuteTestAsync(test.Input);
                    var result = await client.SubmitTestAsync(test.TestId, output);
                    if (result.Correct)
                    {
                        Console.WriteLine($"Output for test {i} was accepted");
                    }
                    else
                    {
                        Console.WriteLine($"Output for test {i} was rejected");
                        using var inputStream = File.Create(FailedInputPath);
                        JsonHelper.Serialize(inputStream, test.Input);
                        using var outputStream = File.Create(FailedOutputPath);
                        JsonHelper.Serialize(outputStream, output);
                        Console.WriteLine("Input and output were dumped");
                        return;
                    }
                }
                Console.WriteLine("All outputs were accepted");
            }
        }

        public abstract ValueTask<TOutput> ExecuteTestAsync(TInput input);
    }
}
