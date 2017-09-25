using System;

namespace Eml.PipelineFramework.Contracts.Entities.Core
{
    public interface IEntityBaseAuditable : IEntityBase
    {
        string UpdatedBy { get; set; }
        DateTime? DateUpdated { get; set; }
    }
}
