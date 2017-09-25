using System.ComponentModel.Composition;
using Eml.ClassFactory.Contracts;
using Eml.Contracts.Attributes;
using Eml.Contracts.Services;
using Eml.PipelineFramework.Contracts.Infrastructure;
using Eml.PipelineFramework.Contracts.Modules.BasesClasses;
using Eml.PipelineFramework.Contracts.Pipelines;

namespace Eml.PipelineFramework.Tests.Unit.Modules
{
    [ModuleVersion(2, PipelineModuleId.ValidateAccountModule, typeof(ValidateAccountFakeModule))]
    [Export(typeof(IAccountingFakeModuleBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ValidateAccountFakeModule : AccountingFakeModuleBase,IAccountingFakeModuleBase
    {
        [ImportingConstructor]
        public ValidateAccountFakeModule(IClockService clockService, IClassFactory classFactory)
                    : base(clockService, classFactory)
        {
            System.Console.WriteLine("ValidateAccountFakeModule -> Executing Constructor - FakeModule");
        }

        public void Initialize(IAccountingFakePipeline pipeline)
        {
            System.Console.WriteLine("ValidateAccountFakeModule -> Executing Initialize - FakeModule");
        }

        public void UnInitialize(IAccountingFakePipeline pipeline)
        {
            System.Console.WriteLine("ValidateAccountFakeModule -> Executing UnInitialize - FakeModule");
        }
    }
}
