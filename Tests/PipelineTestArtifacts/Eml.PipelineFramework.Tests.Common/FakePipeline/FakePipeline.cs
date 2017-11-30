﻿using System.ComponentModel.Composition;
{
    [Export(typeof(IFakePipeline))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FakePipeline: IFakePipeline
    {
        private const string PIPELINE_NAME = "FakePipeline";

        [Export(PIPELINE_NAME)]
        public ModuleDelegate<IFakePipelineContext> ValidateAccount { get; set; }

        [Export(PIPELINE_NAME)]
        public ModuleDelegate<IFakePipelineContext> SetJournal { get; set; }
    }
}