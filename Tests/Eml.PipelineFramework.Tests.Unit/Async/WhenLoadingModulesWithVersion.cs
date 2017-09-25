using System.Threading.Tasks;
using Eml.PipelineFramework.Accounting;
using Eml.PipelineFramework.Tests.Unit.BaseClasses;
using Eml.PipelineFramework.Tests.Unit.FakePipeline;
using NUnit.Framework;
using Shouldly;

namespace Eml.PipelineFramework.Tests.Unit.Async
{
    [TestFixture]
    public class WhenLoadingModulesWithVersion : IntegrationTestBase
    {
        [Test]
        public async Task Pipeline_ShouldExecuteHighestVersion()
        {
            var context = new AccountingPipelineContext();
            var pipeline = context.CreatePipelineHost(classFactory);

            await pipeline.ExecuteAsync();

            context.Messages.Count.ShouldBe(3, "Should be called exactly thrice.");
            context.Messages.Contains("Lowest Version.").ShouldBeFalse();
            context.Messages.Contains("Highest Version.").ShouldBeTrue();
            context.Messages.Contains("Same module but different namespace.").ShouldBeTrue();
            context.Messages.Contains("Module from another assembly.").ShouldBeTrue();
        }

        [Test]
        public async Task Pipeline_ShouldExecuteModulesWithDiffentNamespace()
        {
            var context = new AccountingPipelineContext();
            var pipeline = context.CreatePipelineHost(classFactory);

            await pipeline.ExecuteAsync();

            context.Messages.Count.ShouldBe(3, "Should be called exactly thrice.");
            context.Messages.Contains("Lowest Version.").ShouldBeFalse();
            context.Messages.Contains("Highest Version.").ShouldBeTrue();
            context.Messages.Contains("Same module but different namespace.").ShouldBeTrue();
            context.Messages.Contains("Module from another assembly.").ShouldBeTrue();
        }

        [Test]
        public void Pipeline_ShouldNotThrowErrorIfNoneFound()
        {
            var context = new FakePipelineNoModuleContext();
            var pipeline = context.CreatePipelineHost(classFactory);

            Should.NotThrow(async () => await pipeline.ExecuteAsync());
            context.Messages.Count.ShouldBe(0);
        }
    }
}
