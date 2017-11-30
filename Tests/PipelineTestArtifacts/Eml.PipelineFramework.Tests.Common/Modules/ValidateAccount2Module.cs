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
    [ModuleVersion(2, PipelineModuleId.ValidateAccountModule, typeof(ValidateAccount2Module))]
    [Export(typeof(IAccountingModuleBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ValidateAccount2Module : AccountingModuleBase, IValidateAccountModule
    {
        [ImportingConstructor]
        public ValidateAccount2Module(IClockService clockService, IClassFactory classFactory)
                    : base(clockService, classFactory)
        {
        }

        public void ValidateAccount(IAccountingPipelineContext e)
        {
            System.Console.WriteLine("ValidateAccount2Module -> Executing ValidateAccount - Highest Version");
            e.Messages.Add("Highest Version.");
        }

        public void Initialize(IAccountingPipeline pipeline)
        {
            System.Console.WriteLine("ValidateAccount2Module -> Initializing - Highest Version");
            pipeline.ValidateAccount += ValidateAccount;
        }

        public void UnInitialize(IAccountingPipeline pipeline)
        {
            if (pipeline.ValidateAccount == null) return;

            System.Console.WriteLine("ValidateAccount2Module -> Executing UnInitialize - Highest Version");
            pipeline.ValidateAccount -= ValidateAccount;
        }
    }
}
