using System.ComponentModel.Composition;
using Eml.Contracts.Modules;
using Eml.PipelineFramework.Contracts.PipelineContexts;
using Eml.PipelineFramework.Contracts.Pipelines;

namespace Eml.PipelineFramework.Accounting
{
    [Export(typeof(IAccountingPipeline)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccountingPipeline : IAccountingPipeline
    {
        public ModuleDelegate<IAccountingPipelineContext> ValidateAccount { get; set; }

        public ModuleDelegate<IAccountingPipelineContext> SetJournal { get; set; }

        public ModuleDelegate<IAccountingPipelineContext> SetLedger { get; set; }

        public ModuleDelegate<IAccountingPipelineContext> SetTrialBalance { get; set; }

        public ModuleDelegate<IAccountingPipelineContext> SetAdjustingEntry { get; set; }

        public ModuleDelegate<IAccountingPipelineContext> SetAdjustedTrialBalance { get; set; }

        public ModuleDelegate<IAccountingPipelineContext> SetFinancialStatement { get; set; }

        public ModuleDelegate<IAccountingPipelineContext> SetClosingEntry { get; set; }

        public ModuleDelegate<IAccountingPipelineContext> SetClosingTrialBalance { get; set; }

        public ModuleDelegate<IAccountingPipelineContext> SetReverseEntry { get; set; }
    }
}
