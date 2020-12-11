using System.IO;
using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using TestsGenerator;
using System.Text;
using System.Collections.Generic;

namespace TestsProject
{
    class Generator
    {
        public Task Generate(List<string> inputFiles, string outputPath, int maxParallelismDegree )
        {
            var options = new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = maxParallelismDegree };

            var openFileBlock = new TransformBlock<string, string>( async filePath => await File.ReadAllTextAsync(filePath), options);

            var generateTestsBlock = new TransformManyBlock<string, TestUnit>( fileCode => TestsGenerator.TestsGenerator.GenerateTests(fileCode), options);
            var writeToFileBlock = new ActionBlock<TestUnit>(async TestUnit => await File.WriteAllTextAsync(
                Path.Combine(outputPath, TestUnit.TestName) + ".cs", TestUnit.TestCode));

            var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };
            openFileBlock.LinkTo(generateTestsBlock, linkOptions);
            generateTestsBlock.LinkTo(writeToFileBlock, linkOptions);

            return writeToFileBlock.Completion;
        }
    }
}
