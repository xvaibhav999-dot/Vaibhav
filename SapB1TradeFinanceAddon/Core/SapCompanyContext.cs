using SAPbobsCOM;
using SAPbouiCOM;

namespace SapB1TradeFinanceAddon.Core
{
    public sealed class SapCompanyContext
    {
        public Application UiApp { get; }
        public Company Company { get; }

        public SapCompanyContext(Application uiApp, Company company)
        {
            UiApp = uiApp;
            Company = company;
        }
    }
}
