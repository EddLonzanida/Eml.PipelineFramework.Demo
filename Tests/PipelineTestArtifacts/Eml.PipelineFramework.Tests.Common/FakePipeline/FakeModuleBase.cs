using Eml.ClassFactory.Contracts;namespace Eml.PipelineFramework.Tests.Common.FakePipeline
{
    public abstract class FakeModuleBase
    {
        public IClassFactory Factory { get; set; }
    }
}
