using System.Collections.Generic;
using Eml.Contracts.Pipelines;
using Eml.PipelineFramework.Contracts.Entities;

namespace Eml.PipelineFramework.Contracts.PipelineContexts
{
    public interface IAccountingPipelineContext : IPipelineContextBase
    {
        IEform Eform { get; set; }
        IList<string> Messages { get; set; }
    }
}
