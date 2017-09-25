using Eml.ClassFactory.Contracts;
using Eml.Contracts.Services;

namespace Eml.PipelineFramework.Contracts.Modules.BasesClasses
{
    public abstract class AccountingModuleBase
    {
        public IClockService ClockService { get; set; }
        public IClassFactory ClassFactory { get; set; }

        protected AccountingModuleBase(IClockService clockService, IClassFactory classFactory)
        {
            ClockService = clockService;
            ClassFactory = classFactory;
        }
    }
}
