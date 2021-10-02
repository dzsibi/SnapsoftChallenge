using System;
using System.Threading.Tasks;
using Framework;
using SanityCheck.Model;

namespace SanityCheck
{
    class Program : Runner<Input, Output>
    {
        static Task Main(string[] args) => new Program().RunAsync(args);

        public override string ProblemId => "sanity-check";

        public async override ValueTask<Output> ExecuteTestAsync(Input input)
        {
            throw new NotImplementedException();
        }
    }
}
