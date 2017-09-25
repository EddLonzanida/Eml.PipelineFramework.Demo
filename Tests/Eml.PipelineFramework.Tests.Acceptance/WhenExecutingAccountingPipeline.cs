using System.Collections.Generic;
using System.Linq;
using Eml.Contracts.Modules;
using Eml.MefBootstrapper;
using Eml.PipelineFramework.Contracts.Modules.BasesClasses;
using Eml.PipelineFramework.Contracts.PipelineContexts;
using Eml.PipelineFramework.Contracts.Pipelines;
using NUnit.Framework;
using Shouldly;

namespace Eml.PipelineFramework.Tests.Acceptance
{
    [TestFixture]
    public class WhenExecutingAccountingPipeline
    {
        [SetUp]
        public void Setup()
        {
            MefLoader.Init();
        }

        [Test]
        public void AccountingPipeline_ShouldBeDiscoverable()
        {
            var exported = MefBootstrapper.ClassFactory.Mef.GetExportedValue<IAccountingPipeline>();
            exported.ShouldNotBeNull();
        }

        [Test]
        public void AccountingModules_ShouldBeDiscoverable()
        {
            var exported = MefBootstrapper.ClassFactory.Mef.GetExportedValue<IAccountingModuleBase>();
            exported.ShouldNotBeNull();
        }

        [Test]
        public void AccountingPipelineDelegates_ShouldBeDiscoverable()
        {
            var exported = MefBootstrapper.ClassFactory.Mef.GetExportedValue<IAccountingPipeline>();

            var pipelineItems = GetPipelineItems(exported);
            exported.ShouldNotBeNull();
            pipelineItems.Count.ShouldBe(10);
        }

        private static List<ModuleDelegate<IAccountingPipelineContext>> GetPipelineItems(IAccountingPipeline pipelineItemsContainer)
        {
            var pipelineItems = pipelineItemsContainer.GetType()
                .GetProperties()
                .Select(p => p.GetValue(pipelineItemsContainer, null) as ModuleDelegate<IAccountingPipelineContext>)
                .Where(p => p == null)
                .ToList();
            return pipelineItems;
        }

        [TearDown]
        public void TearDown()
        {
            MefBootstrapper.ClassFactory.Mef?.Dispose();
        }
    }
}
