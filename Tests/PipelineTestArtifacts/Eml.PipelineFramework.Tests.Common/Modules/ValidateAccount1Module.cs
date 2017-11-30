using System.ComponentModel.Composition;
using Eml.ClassFactory.Contracts;
using Eml.Contracts.Attributes;
using Eml.Contracts.Services;
using Eml.PipelineFramework.Contracts.Infrastructure;
using Eml.PipelineFramework.Contracts.Modules.Accounting;
using Eml.PipelineFramework.Contracts.Modules.BasesClasses;
using Eml.PipelineFramework.Contracts.PipelineContexts;
using Eml.PipelineFramework.Contracts.Pipelines;

namespace Eml.PipelineFramework.Tests.Common.Modules
{
    [ModuleVersion(1, PipelineModuleId.ValidateAccountModule, typeof(ValidateAccount1Module))]
    [Export(typeof(IAccountingModuleBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ValidateAccount1Module : AccountingModuleBase, IValidateAccountModule
    {
        [ImportingConstructor]
        public ValidateAccount1Module(IClockService clockService, IClassFactory classFactory)
                   : base(clockService, classFactory)
        {
        }
        public void ValidateAccount(IAccountingPipelineContext e)
        {
            System.Console.WriteLine("ValidateAccount1Module -> Executing ValidateAccount - Lowest Version");
            e.Messages.Add("Lowest Version.");
        }

        public void Initialize(IAccountingPipeline pipeline)
        {
            System.Console.WriteLine("ValidateAccount1Module -> Initializing - Lowest Version");
            pipeline.ValidateAccount += ValidateAccount;
        }

        public void UnInitialize(IAccountingPipeline pipeline)
        {
            if (pipeline.ValidateAccount == null) return;

            System.Console.WriteLine("ValidateAccount1Module -> Executing UnInitialize - Lowest Version");
            pipeline.ValidateAccount -= ValidateAccount;
        }
    }
}
