using Eml.ClassFactory.Contracts;
using Eml.MefBootstrapper;
using NUnit.Framework;

namespace Eml.PipelineFramework.Tests.Unit.BaseClasses
{
    public abstract class IntegrationTestBase
    {
        protected IClassFactory classFactory;

        [SetUp]
        public void SetUp()
        {
            MefLoader.Init();
            classFactory = MefBootstrapper.ClassFactory.Mef.GetExportedValue<IClassFactory>();
        }

        [TearDown]
        public void TearDown()
        {
            MefBootstrapper.ClassFactory.Mef?.Dispose();
        }
    }
}
