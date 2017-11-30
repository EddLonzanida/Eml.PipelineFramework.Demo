using System;
using System.ComponentModel.Composition;
using System.Linq;
using Eml.PipelineFramework.Tests.Integration.Conventions.TestCases;
using NUnit.Framework;
using Shouldly;

namespace Eml.PipelineFramework.Tests.Integration.Conventions
{
    public class AllModules
    {
        [Test]
        [TestCaseSource(typeof(AllExportsTestCases))]
        public void ShouldHaveNonSharedAttribute(Type exportedType)
        {
            var partCreationPolicyAttribute = exportedType
                .GetCustomAttributes(typeof(PartCreationPolicyAttribute), true)
                .FirstOrDefault();

            partCreationPolicyAttribute.ShouldNotBeNull();

            var creationPolicyAttribute = partCreationPolicyAttribute as PartCreationPolicyAttribute;
            creationPolicyAttribute?.CreationPolicy.ShouldBe(CreationPolicy.NonShared);
        }

        [Test]
        [TestCaseSource(typeof(AllModulesTestCases))]
        public void ShouldEndNameWithModule(Type exportedType)
        {
            exportedType.Name.EndsWith("Module").ShouldBeTrue();
        }
    }
}
