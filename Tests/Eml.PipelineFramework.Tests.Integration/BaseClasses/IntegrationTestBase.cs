using Eml.ClassFactory.Contracts;
using NUnit.Framework;

namespace Eml.PipelineFramework.Tests.Integration.BaseClasses
{
    public abstract class IntegrationTestBase
    {
        protected IClassFactory classFactory;

        [OneTimeSetUp]
        public void SetUp()
        {
            Mef.Bootstrapper.Init();
            classFactory = Mef.ClassFactory.Get();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Mef.ClassFactory.Dispose();
        }
    }
}
