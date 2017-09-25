
using Eml.Contracts.Entities;

namespace Eml.PipelineFramework.Contracts.Entities.Core
{
    public interface IEntityBase: IEntityBase<int>
    {
        string CompanyCode { get; set; }
    }
}
