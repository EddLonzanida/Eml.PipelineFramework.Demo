
namespace Eml.PipelineFramework.Tests.Common.FakePipelineContracts
{
    public interface IFakeJournalModule : IFakeModuleBase
    {
        void SetJournal(IFakePipelineContext e);
    }
}
