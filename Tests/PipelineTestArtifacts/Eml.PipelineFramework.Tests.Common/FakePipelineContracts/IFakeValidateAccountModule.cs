namespace Eml.PipelineFramework.Tests.Common.FakePipelineContracts
{
    public interface IFakeValidateAccountModule : IFakeModuleBase
    {
        void ValidateAccount(IFakePipelineContext e);
    }
}
