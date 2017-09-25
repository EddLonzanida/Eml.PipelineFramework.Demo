using System.Collections.Generic;
using Eml.ClassFactory.Contracts;
using Eml.Contracts.Pipelines;
using Eml.PipelineFramework.Contracts.Entities;
using Eml.PipelineFramework.Contracts.Modules.BasesClasses;
using Eml.PipelineFramework.Contracts.PipelineContexts;
using Eml.PipelineFramework.Contracts.Pipelines;

namespace Eml.PipelineFramework.Accounting
{
    public class AccountingFakePipelineContext : IAccountingPipelineContext
    {
        public IEform Eform { get; set; }
        public IList<string> Messages { get; set; } = new List<string>();
        public IPipelineHost CreatePipelineHost(IClassFactory classFactory)
        {
            return new PipelineHost<IClassFactory, IAccountingFakePipeline, IAccountingFakeModuleBase, IAccountingPipelineContext>
                (classFactory, this);
        }
    }
}