using Eml.Contracts.Modules;
using Eml.Contracts.Pipelines;

namespace Eml.PipelineFramework.Tests.Common.FakePipelineContracts
{
    public interface IFakePipeline : IFakePipeline<IFakePipelineContext>
    {
    }

    public interface IFakePipeline<T> : IPipelineItemsContainerBase
        where T : class
    {
        ModuleDelegate<T> ValidateAccount { get; set; }
        ModuleDelegate<T> SetJournal { get; set; }
    }
}
