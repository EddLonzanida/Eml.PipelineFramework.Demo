namespace Eml.PipelineFramework.Tests.Unit.FakePipelineContracts
{
    public interface IFakeValidateAccountModule : IFakeModuleBase
    {
        void ValidateAccount(IFakePipelineContext e);
    }
}
