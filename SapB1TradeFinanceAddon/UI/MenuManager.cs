using SAPbouiCOM;

namespace SapB1TradeFinanceAddon.UI
{
    public class MenuManager
    {
        private readonly Application _app;

        public MenuManager(Application app)
        {
            _app = app;
        }

        public void LoadMenus()
        {
            var menus = _app.Menus;
            var parent = menus.Item("43520"); // Modules
            var cp = (MenuCreationParams)_app.CreateObject(BoCreatableObjectType.cot_MenuCreationParams);
            cp.Type = BoMenuType.mt_POPUP;
            cp.UniqueID = "TF_ROOT";
            cp.String = "Trade Finance";
            parent.SubMenus.AddEx(cp);

            var lc = (MenuCreationParams)_app.CreateObject(BoCreatableObjectType.cot_MenuCreationParams);
            lc.Type = BoMenuType.mt_STRING;
            lc.UniqueID = "TF_LC";
            lc.String = "Letter of Credit";
            menus.Item("TF_ROOT").SubMenus.AddEx(lc);

            var bg = (MenuCreationParams)_app.CreateObject(BoCreatableObjectType.cot_MenuCreationParams);
            bg.Type = BoMenuType.mt_STRING;
            bg.UniqueID = "TF_BG";
            bg.String = "Bank Guarantee";
            menus.Item("TF_ROOT").SubMenus.AddEx(bg);
        }
    }
}
