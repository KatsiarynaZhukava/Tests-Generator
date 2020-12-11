using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsProject
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int maxParallelismDegree = 3;
            List<string> inputPaths = new List<string>() { @"..\..\TestedClasses.cs" };
            string outputPath = @"..\..\GeneratedTests";
            new Generator().Generate(inputPaths, outputPath, maxParallelismDegree);
            Console.ReadKey();
        }
    }
}
