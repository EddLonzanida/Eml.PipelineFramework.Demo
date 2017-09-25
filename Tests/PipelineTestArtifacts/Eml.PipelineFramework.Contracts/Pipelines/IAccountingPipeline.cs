using Eml.Contracts.Modules;
using Eml.Contracts.Pipelines;
using Eml.PipelineFramework.Contracts.PipelineContexts;

namespace Eml.PipelineFramework.Contracts.Pipelines
{
    public interface IAccountingPipeline : IAccountingPipeline<IAccountingPipelineContext>
    {
    }

    public interface IAccountingPipeline<T> : IPipelineItemsContainerBase
        where T : class
    {
        ModuleDelegate<T> ValidateAccount { get; set; }
        ModuleDelegate<T> SetJournal { get; set; }
        ModuleDelegate<T> SetLedger { get; set; }
        ModuleDelegate<T> SetTrialBalance { get; set; }
        ModuleDelegate<T> SetAdjustingEntry { get; set; }
        ModuleDelegate<T> SetAdjustedTrialBalance { get; set; }
        ModuleDelegate<T> SetFinancialStatement { get; set; }
        ModuleDelegate<T> SetClosingEntry { get; set; }
        ModuleDelegate<T> SetClosingTrialBalance { get; set; }
        ModuleDelegate<T> SetReverseEntry { get; set; }

    }
}
