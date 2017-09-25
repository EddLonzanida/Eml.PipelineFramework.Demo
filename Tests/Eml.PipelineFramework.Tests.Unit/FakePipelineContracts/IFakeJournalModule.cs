
namespace Eml.PipelineFramework.Tests.Unit.FakePipelineContracts
{
    public interface IFakeJournalModule : IFakeModuleBase
    {
        void SetJournal(IFakePipelineContext e);
    }
}
