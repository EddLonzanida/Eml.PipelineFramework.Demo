namespace Eml.PipelineFramework.Contracts.Infrastructure
{
    public static class PipelineModuleId
    {
        public const string ValidateAccountModule = "ValidateAccountModule";
        public const string SetJournalModule = "SetJournalModule";
        public const string SetLedgerModule = "SetLedgerModule";
        public const string SetTrialBalanceModule = "SetTrialBalanceModule";
        public const string SetAdjustingEntryModule = "SetAdjustingEntryModule";
        public const string SetAdjustedTrialBalanceModule = "SetAdjustedTrialBalanceModule";
        public const string SetFinancialStatementModule = "SetFinancialStatementModule";
        public const string SetClosingEntryModule = "SetClosingEntryModule";
        public const string SetClosingTrialBalanceModule = "SetClosingTrialBalanceModule";
        public const string SetReverseEntryModule = "SetReverseEntryModule";
    }
}
