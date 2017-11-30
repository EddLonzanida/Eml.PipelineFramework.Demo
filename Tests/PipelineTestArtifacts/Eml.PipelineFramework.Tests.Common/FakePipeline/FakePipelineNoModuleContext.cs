﻿using System.Collections.Generic;
{
    public class FakePipelineNoModuleContext : IFakePipelineContext
    {
        public IList<string> Messages { get; set; } = new List<string>();
        public IPipelineHost CreatePipelineHost(IClassFactory classFactory)
        {
            return new PipelineHost<IClassFactory, IFakePipeline, IFakeMissingModuleBase, IFakePipelineContext>
                (classFactory, this);
        }
    }
}