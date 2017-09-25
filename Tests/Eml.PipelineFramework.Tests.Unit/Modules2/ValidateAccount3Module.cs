using System.ComponentModel.Composition;
using Eml.ClassFactory.Contracts;
using Eml.Contracts.Attributes;
using Eml.Contracts.Services;
using Eml.PipelineFramework.Contracts.Infrastructure;
using Eml.PipelineFramework.Contracts.Modules.Accounting;
using Eml.PipelineFramework.Contracts.Modules.BasesClasses;
using Eml.PipelineFramework.Contracts.PipelineContexts;
using Eml.PipelineFramework.Contracts.Pipelines;

namespace Eml.PipelineFramework.Tests.Unit.Modules2
{
    [ModuleVersion(1, PipelineModuleId.ValidateAccountModule, typeof(ValidateAccount3Module))]
    [Export(typeof(IAccountingModuleBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ValidateAccount3Module : AccountingModuleBase, IValidateAccountModule
    {
        [ImportingConstructor]
        public ValidateAccount3Module(IClockService clockService, IClassFactory classFactory)
            : base(clockService, classFactory)
        {
        }

        public void ValidateAccount(IAccountingPipelineContext e)
        {
            System.Console.WriteLine("ValidateAccount3Module -> Executing ValidateAccount - Same module but different namespace.");
            e.Messages.Add("Same module but different namespace."); 
        }

        public void Initialize(IAccountingPipeline pipeline)
        {
            System.Console.WriteLine("ValidateAccount3Module -> Initializing - Same module but different namespace.");
            pipeline.ValidateAccount += ValidateAccount;
        }
        public void UnInitialize(IAccountingPipeline pipeline)
        {
            if (pipeline.ValidateAccount == null) return;

            System.Console.WriteLine("ValidateAccount3Module -> Executing UnInitialize - Same module but different namespace.");
            pipeline.ValidateAccount -= ValidateAccount;
        }
    }
}
