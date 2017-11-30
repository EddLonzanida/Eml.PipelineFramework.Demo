using System.Collections.Generic;using Eml.ClassFactory.Contracts;using Eml.Contracts.Pipelines;using Eml.PipelineFramework.Tests.Common.FakePipelineContracts;namespace Eml.PipelineFramework.Tests.Common.FakePipeline
{
    public class FakePipelineNoModuleContext : IFakePipelineContext
    {
        public IList<string> Messages { get; set; } = new List<string>();
        public IPipelineHost CreatePipelineHost(IClassFactory classFactory)
        {
            return new PipelineHost<IClassFactory, IFakePipeline, IFakeMissingModuleBase, IFakePipelineContext>
                (classFactory, this);
        }
    }
}