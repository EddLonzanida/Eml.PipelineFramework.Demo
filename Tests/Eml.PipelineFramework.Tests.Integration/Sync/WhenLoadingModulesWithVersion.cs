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
    public class WhenLoadingModulesWithVersion : IntegrationTestBase
    {
        [Test]
        public void Pipeline_ShouldExecuteHighestVersion()
        {
            var context = new AccountingPipelineContext();
            var pipeline = context.CreatePipelineHost(classFactory);

            pipeline.Execute();

            context.Messages.Count.ShouldBe(3, "Should be called exactly thrice.");
            context.Messages.Contains("Lowest Version.").ShouldBeFalse();
            context.Messages.Contains("Highest Version.").ShouldBeTrue();
            context.Messages.Contains("Same module but different namespace.").ShouldBeTrue();
            context.Messages.Contains("Module from another assembly.").ShouldBeTrue();
        }

        [Test]
        public void Pipeline_ShouldExecuteAllModulesWithDiffentNamespace()
        {
            var context = new AccountingPipelineContext();
            var pipeline = context.CreatePipelineHost(classFactory);

            pipeline.Execute();

            context.Messages.Count.ShouldBe(3, "Should be called exactly thrice.");
            context.Messages.Contains("Lowest Version.").ShouldBeFalse();
            context.Messages.Contains("Highest Version.").ShouldBeTrue();
            context.Messages.Contains("Same module but different namespace.").ShouldBeTrue();
            context.Messages.Contains("Module from another assembly.").ShouldBeTrue();
        }

        [Test]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void Pipeline_ShouldUnloadAllDiscoveredModules()
        {
            var context = new AccountingPipelineContext();
            var pipeline = context.CreatePipelineHost(classFactory);

            pipeline.Execute();

            context.Messages.Count.ShouldBe(3, "Should be called exactly thrice.");
            context.Messages.Contains("Lowest Version.").ShouldBeFalse();
            context.Messages.Contains("Highest Version.").ShouldBeTrue();
            context.Messages.Contains("Same module but different namespace.").ShouldBeTrue();
            context.Messages.Contains("Module from another assembly.").ShouldBeTrue();


            dotMemory.Check(memory =>
            {
                memory.GetObjects(where => where.Type.Is<ValidateAccount1Module>()).ObjectsCount.ShouldBe(0);
                memory.GetObjects(where => where.Type.Is<ValidateAccount2Module>()).ObjectsCount.ShouldBe(0);
                memory.GetObjects(where => where.Type.Is<ValidateAccount3Module>()).ObjectsCount.ShouldBe(0);
                memory.GetObjects(where => where.Type.Is<ValidateAccount4Module>()).ObjectsCount.ShouldBe(0);
                memory.GetObjects(where => where.Type.Is<AccountingPipeline>()).ObjectsCount.ShouldBe(0);
                memory.GetObjects(where => where.Type.Is<FakePipeline>()).ObjectsCount.ShouldBe(0);
            });
        }


        [Test]
        public void Pipeline_ShouldNotThrowErrorIfModulesNotFound()
        {
            var context = new FakePipelineNoModuleContext();
            var pipeline = context.CreatePipelineHost(classFactory);

            Should.NotThrow(() => pipeline.Execute());

            context.Messages.Count.ShouldBe(0);
        }

        [Test]
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        public void Pipeline_ShouldNotThrowErrorIfPipelineHostNotFound()
        {
            var context = new AccountingFakePipelineContext();
            var pipeline = context.CreatePipelineHost(classFactory);

            Should.NotThrow(() => pipeline.Execute());

            //context.Messages.Count.ShouldBe(0);
            dotMemory.Check(memory =>
            {
                memory.GetObjects(where => where.Type.Is<ValidateAccountFakeModule>()).ObjectsCount.ShouldBe(0);
            });
        }

    }
}
