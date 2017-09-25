using System.Collections.Generic;
using Eml.Contracts.Pipelines;

namespace Eml.PipelineFramework.Tests.Unit.FakePipelineContracts
{
    public interface IFakePipelineContext : IPipelineContextBase
    {
        IList<string> Messages { get; set; }
    }
}
