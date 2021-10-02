using System;
using System.Threading.Tasks;
using Barrel.Model;
using Framework;

namespace Barrel
{
    class Program : Runner<Input, Output>
    {
        static Task Main(string[] args) => new Program().RunAsync(args);

        public override string ProblemId => "barrel";

        public async override ValueTask<Output> ExecuteTestAsync(Input input)
        {
            throw new NotImplementedException();
        }
    }
}
