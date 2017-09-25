# [Eml.PipelineFramework](https://preview.nuget.org/packages/Eml.PipelineFramework/)
Create a modular architecture using PipelineFramework via MEF.

Below is a sample of an Accounting pipeline. 

Each step from top to bottom (ValidateAccount -> SetJournal -> ... -> SetReverseEntry) is handled by a separate module.
    
```javascript
    [Export(typeof(IAccountingPipeline))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccountingPipeline : IAccountingPipeline
    {
        public ModuleDelegate<IAccountingPipelineContext> ValidateAccount { get; set; }
        public ModuleDelegate<IAccountingPipelineContext> SetJournal { get; set; }
        public ModuleDelegate<IAccountingPipelineContext> SetLedger { get; set; }
        public ModuleDelegate<IAccountingPipelineContext> SetTrialBalance { get; set; }
        public ModuleDelegate<IAccountingPipelineContext> SetAdjustingEntry { get; set; }
        public ModuleDelegate<IAccountingPipelineContext> SetAdjustedTrialBalance { get; set; }
        public ModuleDelegate<IAccountingPipelineContext> SetFinancialStatement { get; set; }
        public ModuleDelegate<IAccountingPipelineContext> SetClosingEntry { get; set; }
        public ModuleDelegate<IAccountingPipelineContext> SetClosingTrialBalance { get; set; }
        public ModuleDelegate<IAccountingPipelineContext> SetReverseEntry { get; set; }
    }
 ```

## Getting Started
### Creating a module
1. Decorate your module with ModuleVersion.
2. Decorate your module with Export attribute for MEF discovery.
3. Decorate your module with PartCreationPolicy(CreationPolicy.NonShared).

* If your module happens to be in another assembly, make sure the module asembly output 
    directory is pointed at the location of the executing assembly. 
    Or reference the module assembly from your main project.
    
```javascript
    [ModuleVersion(1, PipelineModuleId.ValidateAccountModule, typeof(ValidateAccount1Module))]
    [Export(typeof(IAccountingModuleBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ValidateAccount1Module : AccountingModuleBase, IValidateAccountModule
    {
        [ImportingConstructor]
        public ValidateAccount1Module(IClockService clockService, IClassFactory classFactory)
                   : base(clockService, classFactory)
        {
        }
        public void ValidateAccount(IAccountingPipelineContext e)
        {
            System.Console.WriteLine("ValidateAccount1Module -> Executing ValidateAccount - Lowest Version");
            e.Messages.Add("Lowest Version.");
        }

        public void Initialize(IAccountingPipeline pipeline)
        {
            System.Console.WriteLine("ValidateAccount1Module -> Initializing - Lowest Version");
            pipeline.ValidateAccount += ValidateAccount;
        }

        public void UnInitialize(IAccountingPipeline pipeline)
        {
            if (pipeline.ValidateAccount == null) return;

            System.Console.WriteLine("ValidateAccount1Module -> Executing UnInitialize - Lowest Version");
            pipeline.ValidateAccount -= ValidateAccount;
        }
    }
 ```

### Creating the AccountingPipelineContext
```javascript
    public class AccountingPipelineContext : IAccountingPipelineContext
    {
        public IEform Eform { get; set; }
        public IList<string> Messages { get; set; } = new List<string>();
        public IPipelineHost CreatePipelineHost(IClassFactory classFactory)
        {
            return new PipelineHost<IClassFactory, IAccountingPipeline, IAccountingModuleBase, IAccountingPipelineContext>
                (classFactory, this);
        }
    }
```

## Usage
Instantiate AccountingPipeline via the context.**CreatePipelineHost**
```javascript
    [Test]
    public async Task ShouldExecuteAllModulesWithDiffentNamespace()
    {
        var context = new AccountingPipelineContext();
        var pipeline = context.CreatePipelineHost(classFactory);

        await pipeline.ExecuteAsync();

        context.Messages.Count.ShouldBe(3, "Should be called exactly thrice.");
        context.Messages.Contains("Lowest Version.").ShouldBeFalse();
        context.Messages.Contains("Highest Version.").ShouldBeTrue();
        context.Messages.Contains("Same module but different namespace.").ShouldBeTrue();
        context.Messages.Contains("Module from another assembly.").ShouldBeTrue();
    }
```

## That's it.
