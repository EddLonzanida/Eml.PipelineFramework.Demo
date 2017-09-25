using System;
using Eml.ClassFactory.Contracts;
using Eml.MefBootstrapper;
using Eml.PipelineFramework.Accounting;

namespace Eml.PipelineFramework.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MefLoader.Init(new[] { "Eml*.dll" });
                var classFactory = MefBootstrapper.ClassFactory.Mef.GetExportedValue<IClassFactory>();

                for (var i = 0; i < 100000; i++)
                {
                    var context = new AccountingPipelineContext();
                    var pipeline = context.CreatePipelineHost(classFactory);
                    var t = pipeline.ExecuteAsync();
                    t.Wait();
                }

                //var container = new CompositionContainer();
                //var factory = new ClassFactory();
                //var module = new ValidateAccountModule4(factory);
                //var accountingPipeline = Substitute.For<IAccountingPipeline>();
                //var accountingPipelineContext = new AccountingPipelineContext();
                //container.ComposeExportedValue(accountingPipeline);
                //container.ComposeParts(module, factory, accountingPipeline);
                //ClassFactory.Mef = container;

                //if (ClassFactory.Mef?.Catalog?.Parts != null)
                //{
                //    foreach (var part in ClassFactory.Mef.Catalog.Parts)
                //    {
                //        System.Console.WriteLine($"{part}");
                //    }

                //    System.Console.WriteLine("");
                //    System.Console.WriteLine($"{ClassFactory.Mef.Catalog?.Parts.Count()} found.");
                //}
                //else System.Console.WriteLine("No parts found.");

                //var pipeline = accountingPipelineContext.CreatePipelineHost(factory);

                //pipeline.Execute();

                //accountingPipeline.Received(2).ValidateAccount(Arg.Any<IAccountingPipelineContext>());
                //accountingPipeline.Received().ValidateAccount += Arg.Any<ModuleDelegate<IAccountingPipelineContext>>();
                //System.Console.WriteLine("Success");
                //System.Console.ReadLine();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                System.Console.ReadLine();
            }
        }
    }
}
