using System;
using SAPbobsCOM;
using SAPbouiCOM;
using SapB1TradeFinanceAddon.Data;
using SapB1TradeFinanceAddon.Services;
using SapB1TradeFinanceAddon.UI;

namespace SapB1TradeFinanceAddon.Core
{
    public class AddonApplication
    {
        public void Run(string[] args)
        {
            var sboGuiApi = new SboGuiApi();
            sboGuiApi.Connect(args[0]);

            var uiApp = sboGuiApi.GetApplication(-1);
            var company = (Company)uiApp.Company.GetDICompany();
            var context = new SapCompanyContext(uiApp, company);

            var repository = new TradeFinanceRepository(company);
            repository.EnsureSchema();

            var lcService = new LcService(repository);
            var bgService = new BgService(repository);
            var menuManager = new MenuManager(uiApp);
            var lcController = new LcFormController(uiApp, lcService);
            var bgController = new BgFormController(uiApp, bgService);

            menuManager.LoadMenus();
            uiApp.ItemEvent += lcController.OnItemEvent;
            uiApp.ItemEvent += bgController.OnItemEvent;

            uiApp.StatusBar.SetText("Trade Finance Add-on (LC/BG) loaded.", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Success);
            System.Windows.Forms.Application.Run();
        }
    }
}
