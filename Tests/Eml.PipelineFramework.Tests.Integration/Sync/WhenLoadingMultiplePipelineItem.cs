using Eml.PipelineFramework.Accounting;
using Eml.PipelineFramework.Modules;
using Eml.PipelineFramework.Tests.Common.FakePipeline;
using Eml.PipelineFramework.Tests.Common.Modules;
using Eml.PipelineFramework.Tests.Common.Modules2;
using Eml.PipelineFramework.Tests.Integration.BaseClasses;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;
using Shouldly;

namespace Eml.PipelineFramework.Tests.Integration.Sync
{
    [TestFixture]
    public class WhenLoadingMultiplePipelineItem : IntegrationTestBase
    {
        [Test]
        public void MultitplePipeline_ShouldBeExecuted()
        {
            //PipelineHost 1
            var accountingPipelineContext = new AccountingPipelineContext();
            var accountingPipeline = accountingPipelineContext.CreatePipelineHost(classFactory);

            accountingPipeline.Execute();

            accountingPipelineContext.Messages.Count.ShouldBe(3, "Should be called exactly thrice.");
            accountingPipelineContext.Messages.Contains("Lowest Version.").ShouldBeFalse();
            accountingPipelineContext.Messages.Contains("Highest Version.").ShouldBeTrue();
            accountingPipelineContext.Messages.Contains("Same module but different namespace.").ShouldBeTrue();
            accountingPipelineContext.Messages.Contains("Module from another assembly.").ShouldBeTrue();

            //PipelineHost 2
            var fakeContext = new FakePipelineContext();
            var fakePipeline = fakeContext.CreatePipelineHost(classFactory);

            fakePipeline.Execute();

            fakeContext.Messages.Count.ShouldBe(2);
            fakeContext.Messages.Contains("FakeModule ValidateAccount.").ShouldBeTrue();
            fakeContext.Messages.Contains("FakeModule SetJournal.").ShouldBeTrue();
        }

        [Test]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void Pipeline_ShouldUnloadAllDiscoveredModules()
        {
            //PipelineHost 1
            var accountingPipelineContext = new AccountingPipelineContext();
            var accountingPipeline = accountingPipelineContext.CreatePipelineHost(classFactory);

            accountingPipeline.Execute();

            accountingPipelineContext.Messages.Count.ShouldBe(3, "Should be called exactly thrice.");
            accountingPipelineContext.Messages.Contains("Lowest Version.").ShouldBeFalse();
            accountingPipelineContext.Messages.Contains("Highest Version.").ShouldBeTrue();
            accountingPipelineContext.Messages.Contains("Same module but different namespace.").ShouldBeTrue();
            accountingPipelineContext.Messages.Contains("Module from another assembly.").ShouldBeTrue();


            //PipelineHost 2
            var fakeContext = new FakePipelineContext();
            var fakePipeline = fakeContext.CreatePipelineHost(classFactory);

            fakePipeline.Execute();

            fakeContext.Messages.Count.ShouldBe(2);
            fakeContext.Messages.Contains("FakeModule ValidateAccount.").ShouldBeTrue();
            fakeContext.Messages.Contains("FakeModule SetJournal.").ShouldBeTrue();

            dotMemory.Check(memory =>
            {
                memory.GetObjects(where => where.Type.Is<FakeModule>()).ObjectsCount.ShouldBe(0);
                memory.GetObjects(where => where.Type.Is<ValidateAccount1Module>()).ObjectsCount.ShouldBe(0);
                memory.GetObjects(where => where.Type.Is<ValidateAccount2Module>()).ObjectsCount.ShouldBe(0);
                memory.GetObjects(where => where.Type.Is<ValidateAccount3Module>()).ObjectsCount.ShouldBe(0);
                memory.GetObjects(where => where.Type.Is<ValidateAccount4Module>()).ObjectsCount.ShouldBe(0);
                memory.GetObjects(where => where.Type.Is<AccountingPipeline>()).ObjectsCount.ShouldBe(0);
                memory.GetObjects(where => where.Type.Is<FakePipeline>()).ObjectsCount.ShouldBe(0);
            });
        }
    }
}
