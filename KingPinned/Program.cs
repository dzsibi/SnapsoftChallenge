using System;
using System.Threading.Tasks;
using Framework;
using KingPinned.Model;

namespace KingPinned
{
    class Program : Runner<Input, Output>
    {
        static Task Main(string[] args) => new Program().RunAsync(args);

        public override string ProblemId => "king-pinned";

        public async override ValueTask<Output> ExecuteTestAsync(Input input)
        {
            throw new NotImplementedException();
        }
    }
}
