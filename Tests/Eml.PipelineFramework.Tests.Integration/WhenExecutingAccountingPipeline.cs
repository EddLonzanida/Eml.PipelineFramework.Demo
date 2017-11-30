using System.Collections.Generic;
using System.Linq;
using Eml.Contracts.Modules;
using Eml.PipelineFramework.Contracts.Modules.BasesClasses;
using Eml.PipelineFramework.Contracts.PipelineContexts;
using Eml.PipelineFramework.Contracts.Pipelines;
using Eml.PipelineFramework.Tests.Integration.BaseClasses;
using NUnit.Framework;
using Shouldly;

namespace Eml.PipelineFramework.Tests.Integration
{
    [TestFixture]
    public class WhenExecutingAccountingPipeline : IntegrationTestBase
    {
        [Test]
        public void AccountingPipeline_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<IAccountingPipeline>();
            exported.ShouldNotBeNull();
        }

        [Test]
        public void AccountingModules_ShouldBeDiscoverable()
        {
            var modules = classFactory.GetLazyExports<IAccountingModuleBase>();
            modules.Count().ShouldBe(4);
        }

        [Test]
        public void AccountingPipelineDelegates_ShouldBeDiscoverable()
        {
            var exported = classFactory.GetExport<IAccountingPipeline>();

            var pipelineItems = GetPipelineItems(exported);
            exported.ShouldNotBeNull();
            pipelineItems.Count.ShouldBe(10);
        }

        [Test]
        public void AccountingPipelines_ShouldNotOverlapScopes()
        {
            var pipeline1 = classFactory.GetExport<IAccountingPipeline>();
            var pipeline2 = classFactory.GetExport<IAccountingPipeline>();

            pipeline1.ValidateAccount += ValidateAccount;
            pipeline1.ValidateAccount.ShouldNotBeNull();
            pipeline2.ValidateAccount.ShouldBeNull();
        }

        private void ValidateAccount(IAccountingPipelineContext e)
        {
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

    }
}
