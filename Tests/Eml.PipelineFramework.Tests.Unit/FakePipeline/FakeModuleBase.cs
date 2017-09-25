using Eml.ClassFactory.Contracts;

namespace Eml.PipelineFramework.Tests.Unit.FakePipeline
{
    public abstract class FakeModuleBase
    {
        public IClassFactory Factory { get; set; }
    }
}
