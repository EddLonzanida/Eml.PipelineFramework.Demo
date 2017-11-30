﻿using System.Collections.Generic;
{
    public class FakePipelineContext : IFakePipelineContext
    {
        public IList<string> Messages { get; set; } = new List<string>();
        public IPipelineHost CreatePipelineHost(IClassFactory classFactory)
        {
            return new PipelineHost<IClassFactory, IFakePipeline, IFakeModuleBase, IFakePipelineContext>
                (classFactory, this);
        }
    }
}