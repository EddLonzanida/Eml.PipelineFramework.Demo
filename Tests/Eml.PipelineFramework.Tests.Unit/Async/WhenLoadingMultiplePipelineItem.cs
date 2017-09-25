using System.Threading.Tasks;
using Eml.PipelineFramework.Accounting;
using Eml.PipelineFramework.Tests.Unit.BaseClasses;
using Eml.PipelineFramework.Tests.Unit.FakePipeline;
using NUnit.Framework;
using Shouldly;

namespace Eml.PipelineFramework.Tests.Unit.Async
{
    [TestFixture]
    public class WhenLoadingMultiplePipelineItem : IntegrationTestBase
    {
        [Test]
        public async Task MultitplePipeline_ShouldBeExecuted()
        {
            //PipelineHost 1
            var accountingPipelineContext = new AccountingPipelineContext();
            var accountingPipeline = accountingPipelineContext.CreatePipelineHost(classFactory);

            await accountingPipeline.ExecuteAsync();

            accountingPipelineContext.Messages.Count.ShouldBe(3, "Should be called exactly thrice.");
            accountingPipelineContext.Messages.Contains("Lowest Version.").ShouldBeFalse();
            accountingPipelineContext.Messages.Contains("Highest Version.").ShouldBeTrue();
            accountingPipelineContext.Messages.Contains("Same module but different namespace.").ShouldBeTrue();
            accountingPipelineContext.Messages.Contains("Module from another assembly.").ShouldBeTrue();

            //PipelineHost 2
            var fakeContext = new FakePipelineContext();
            var fakePipeline = fakeContext.CreatePipelineHost(classFactory);

            await fakePipeline.ExecuteAsync();

            fakeContext.Messages.Count.ShouldBe(2);
            fakeContext.Messages.Contains("FakeModule ValidateAccount.").ShouldBeTrue();
            fakeContext.Messages.Contains("FakeModule SetJournal.").ShouldBeTrue();
        }
    }
}
