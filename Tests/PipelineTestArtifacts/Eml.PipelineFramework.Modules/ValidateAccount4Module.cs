using System;
using System.ComponentModel.Composition;
using Eml.ClassFactory.Contracts;
using Eml.Contracts.Attributes;
using Eml.Contracts.Services;
using Eml.PipelineFramework.Contracts.Infrastructure;
using Eml.PipelineFramework.Contracts.Modules.Accounting;
using Eml.PipelineFramework.Contracts.Modules.BasesClasses;
using Eml.PipelineFramework.Contracts.PipelineContexts;
using Eml.PipelineFramework.Contracts.Pipelines;

namespace Eml.PipelineFramework.Modules
{
    [ModuleVersion(1, PipelineModuleId.ValidateAccountModule, typeof(ValidateAccount4Module))]
    [Export(typeof(IAccountingModuleBase)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class ValidateAccount4Module : AccountingModuleBase, IValidateAccountModule
    {
        [ImportingConstructor]
        public ValidateAccount4Module(IClockService clockService, IClassFactory classFactory)
            : base(clockService, classFactory)
        {
        }

        public void ValidateAccount(IAccountingPipelineContext e)
        {
            Console.WriteLine("ValidateAccount4Module -> Executing ValidateAccount - From Another Assembly.");
            e.Messages.Add("Module from another assembly.");
        }

        public void SetTrialBalance(IAccountingPipelineContext e)
        {

            Console.WriteLine("ValidateAccount4Module -> Executing SetTrialBalance - From Another Assembly.");
            throw new NotImplementedException("This error should not break the pipeline.");
        }

        public void Initialize(IAccountingPipeline pipeline)
        {
            Console.WriteLine("ValidateAccount4Module -> Initialize ValidateAccount - From Another Assembly.");
            pipeline.ValidateAccount += ValidateAccount;
            Console.WriteLine("ValidateAccount4Module -> Initialize SetTrialBalance - From Another Assembly.");
            pipeline.SetTrialBalance += SetTrialBalance;
        }

        public void UnInitialize(IAccountingPipeline pipeline)
        {
            if (pipeline.ValidateAccount == null) return;
            Console.WriteLine("ValidateAccount4Module -> UnInitialize ValidateAccount - From Another Assembly.");
            pipeline.ValidateAccount -= ValidateAccount;
            Console.WriteLine("ValidateAccount4Module -> UnInitialize SetTrialBalance - From Another Assembly.");
            pipeline.SetTrialBalance -= SetTrialBalance;
        }
    }
}
