using System;
using Eml.PipelineFramework.Contracts.Entities.Core;

namespace Eml.PipelineFramework.Contracts.Entities
{
    public interface IEform : IEntityBaseAuditable, IEntitySortable
    {
        int EformParentID { get; set; }
        string Title { get; set; }
        string SubTitle { get; set; }
        int DocType { get; set; }
        string CountryCode { get; set; }
        int StepCount { get; set; }
        int Version { get; set; }
        bool IsNew { get; set; }
        string Description { get; set; }
        DateTime? DatePublished { get; set; }
        string PublishedBy { get; set; }
    }
}