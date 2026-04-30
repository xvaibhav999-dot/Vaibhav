using System;
using SAPbouiCOM;
using SapB1TradeFinanceAddon.Data;
using SapB1TradeFinanceAddon.Services;

namespace SapB1TradeFinanceAddon.UI
{
    public class LcFormController
    {
        private readonly Application _app;
        private readonly LcService _service;

        public LcFormController(Application app, LcService service)
        {
            _app = app;
            _service = service;
        }

        public void OnItemEvent(string formUid, ref ItemEvent pVal, out bool bubble)
        {
            bubble = true;
            if (pVal.FormTypeEx != "UDO_FT_TF_LC" || pVal.BeforeAction || pVal.EventType != BoEventTypes.et_ITEM_PRESSED) return;
            if (pVal.ItemUID != "1") return;

            var form = _app.Forms.Item(formUid);
            var lc = new LetterOfCredit
            {
                Code = GetEdit(form, "txtCode"),
                Name = GetEdit(form, "txtName"),
                CustomerCode = GetEdit(form, "txtCard"),
                Amount = decimal.Parse(GetEdit(form, "txtAmt")),
                Currency = GetEdit(form, "txtCur"),
                IssueDate = DateTime.Parse(GetEdit(form, "txtIssue")),
                ExpiryDate = DateTime.Parse(GetEdit(form, "txtExp")),
                Status = GetEdit(form, "txtSt")
            };
            _service.Create(lc);
        }

        private static string GetEdit(Form form, string uid) => ((EditText)form.Items.Item(uid).Specific).Value;
    }
}
