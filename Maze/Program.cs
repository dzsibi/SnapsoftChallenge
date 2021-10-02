using System;
using System.Threading.Tasks;
using Framework;
using Maze.Model;

namespace Maze
{
    class Program : Runner<Input, Output>
    {
        static Task Main(string[] args) => new Program().RunAsync(args);

        public override string ProblemId => "maze";

        public async override ValueTask<Output> ExecuteTestAsync(Input input)
        {
            throw new NotImplementedException();
        }
    }
}
