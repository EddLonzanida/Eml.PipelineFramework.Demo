using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using Eml.Contracts.Modules;
using Eml.Contracts.Services;
using Eml.PipelineFramework.Accounting;
using Eml.PipelineFramework.Contracts.PipelineContexts;
using Eml.PipelineFramework.Modules;
using NSubstitute;
using NUnit.Framework;

namespace Eml.PipelineFramework.Tests.Unit.Sync
{
    public class WhenLoadingAPipelineWithModule
    {
        [Test]
        public void Pipeline_ShouldInitializeTheCorrectModule()
        {
            var container = new CompositionContainer();
            var clockService = new ClockService();
            var factory = new MefBootstrapper.ClassFactory();
            var module = new ValidateAccount4Module(clockService, factory);
            var accountingPipeline = Substitute.For<AccountingPipeline>();

            var clockServicePart = AttributedModelServices.CreatePart(clockService);
            var factoryPart = AttributedModelServices.CreatePart(factory);
            var modulePart = AttributedModelServices.CreatePart(module);
            var accountingPipelinePart = AttributedModelServices.CreatePart(accountingPipeline);
            var accountingPipelineContext = new AccountingPipelineContext();
            //Manual composition
            var batch = new CompositionBatch(new List<ComposablePart>
            {
                clockServicePart, factoryPart, modulePart, accountingPipelinePart
            }, null);
            container.Compose(batch);
            MefBootstrapper.ClassFactory.Mef = container;
            var pipeline = accountingPipelineContext.CreatePipelineHost(factory);

            pipeline.Execute();

            accountingPipeline.Received(1).ValidateAccount += Arg.Any<ModuleDelegate<IAccountingPipelineContext>>();

            //Manual cleanup to prevent memory leaks that will affect other tests
            batch.RemovePart(clockServicePart);
            batch.RemovePart(factoryPart);
            batch.RemovePart(modulePart);
            batch.RemovePart(accountingPipelinePart);
        }
    }
}
