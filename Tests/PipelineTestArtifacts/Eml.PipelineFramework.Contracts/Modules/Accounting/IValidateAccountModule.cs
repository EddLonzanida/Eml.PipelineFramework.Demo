using Eml.PipelineFramework.Contracts.Modules.BasesClasses;
using Eml.PipelineFramework.Contracts.PipelineContexts;

namespace Eml.PipelineFramework.Contracts.Modules.Accounting
{
    public interface IValidateAccountModule : IAccountingModuleBase
    {
        void ValidateAccount(IAccountingPipelineContext e);
    }
}
