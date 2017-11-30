using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Eml.Contracts.Modules;
using Eml.PipelineFramework.Tests.Integration.Helpers;
using NUnit.Framework;

namespace Eml.PipelineFramework.Tests.Integration.Conventions.TestCases
{
    public class AllModulesTestCases : IEnumerable<TestCaseData>
    {
        public IEnumerator<TestCaseData> GetEnumerator()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var moduleDirectory = new DirectoryInfo(path);
            var assemblies = moduleDirectory.GetAssembliesFromDirectory("Eml*.dll").ToList();
            var results = new List<TestCaseData>();

            assemblies.ForEach(assembly =>
            {
                var exportableClasses = assembly.GetClasses(type => type.IsAssignableTo<IModuleBase>() && type.IsExportable())
                    .Select(type => new TestCaseData(type));
                results.AddRange(exportableClasses);
            });
            return results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
