﻿using Eml.Contracts.Modules;
{
    public interface IFakeModule : IFakeModuleBase, IModuleBase<IFakePipeline>
    {
        void ValidateAccount(IFakePipelineContext e);
    }
}