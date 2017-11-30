using System.ComponentModel.Composition;
using Eml.ClassFactory.Contracts;
using Eml.Contracts.Attributes;
using Eml.PipelineFramework.Tests.Common.FakePipelineContracts;

namespace Eml.PipelineFramework.Tests.Common.FakePipeline
{
    [ModuleVersion(1, "FakeModule", typeof(FakeModule))]
    [Export(typeof(IFakeModuleBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FakeModule : FakeModuleBase, IFakeValidateAccountModule, IFakeJournalModule
    {
        [ImportingConstructor]
        public FakeModule(IClassFactory factory)
        {
            Factory = factory;
        }

        public void ValidateAccount(IFakePipelineContext e)
        {
            System.Console.WriteLine("FakeModule -> Executing ValidateAccount");
            e.Messages.Add("FakeModule ValidateAccount.");
        }

        public void Initialize(IFakePipeline pipeline)
        {
            System.Console.WriteLine("FakeModule -> Initializing - ValidateAccount.");
            pipeline.ValidateAccount += ValidateAccount;

            System.Console.WriteLine("FakeModule -> Initializing - SetJournal.");
            pipeline.SetJournal += SetJournal;
        }

        public void UnInitialize(IFakePipeline pipeline)
        {
            if (pipeline.ValidateAccount != null)
            {
                System.Console.WriteLine("FakeModule -> Executing UnInitialize - ValidateAccount.");
                pipeline.ValidateAccount -= ValidateAccount;
            }

            if (pipeline.SetJournal != null)
            {
                System.Console.WriteLine("FakeModule -> Executing UnInitialize - SetJournal.");
                pipeline.SetJournal -= SetJournal;
            }
        }

        public void SetJournal(IFakePipelineContext e)
        {
            System.Console.WriteLine("FakeModule -> Executing SetJournal");
            e.Messages.Add("FakeModule SetJournal.");
        }
    }
}
