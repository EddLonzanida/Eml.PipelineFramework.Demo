using Eml.Contracts.Modules;

namespace Eml.PipelineFramework.Tests.Unit.FakePipelineContracts
{
    public interface IFakeModule : IFakeModuleBase, IModuleBase<IFakePipeline>
    {
        void ValidateAccount(IFakePipelineContext e);
    }
}
