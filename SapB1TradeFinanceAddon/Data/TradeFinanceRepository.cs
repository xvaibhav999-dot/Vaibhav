using SAPbobsCOM;

namespace SapB1TradeFinanceAddon.Data
{
    public class TradeFinanceRepository
    {
        private readonly Company _company;

        public TradeFinanceRepository(Company company)
        {
            _company = company;
        }

        public void EnsureSchema()
        {
            EnsureUdt("@TF_LC", "TF_LC", BoUTBTableType.bott_NoObject);
            EnsureUdt("@TF_BG", "TF_BG", BoUTBTableType.bott_NoObject);
            EnsureField("@TF_LC", "U_CardCode", "Customer", BoFieldTypes.db_Alpha, 20);
            EnsureField("@TF_LC", "U_Amount", "Amount", BoFieldTypes.db_Float, 11, BoFldSubTypes.st_Price);
            EnsureField("@TF_LC", "U_Currency", "Currency", BoFieldTypes.db_Alpha, 3);
            EnsureField("@TF_LC", "U_IssueDate", "Issue Date", BoFieldTypes.db_Date);
            EnsureField("@TF_LC", "U_ExpiryDate", "Expiry Date", BoFieldTypes.db_Date);
            EnsureField("@TF_LC", "U_Status", "Status", BoFieldTypes.db_Alpha, 20);

            EnsureField("@TF_BG", "U_CardCode", "Vendor", BoFieldTypes.db_Alpha, 20);
            EnsureField("@TF_BG", "U_Amount", "Amount", BoFieldTypes.db_Float, 11, BoFldSubTypes.st_Price);
            EnsureField("@TF_BG", "U_Currency", "Currency", BoFieldTypes.db_Alpha, 3);
            EnsureField("@TF_BG", "U_IssueDate", "Issue Date", BoFieldTypes.db_Date);
            EnsureField("@TF_BG", "U_ExpiryDate", "Expiry Date", BoFieldTypes.db_Date);
            EnsureField("@TF_BG", "U_Status", "Status", BoFieldTypes.db_Alpha, 20);
        }

        private void EnsureUdt(string tableName, string description, BoUTBTableType type)
        {
            var table = (UserTablesMD)_company.GetBusinessObject(BoObjectTypes.oUserTables);
            if (!table.GetByKey(tableName))
            {
                table.TableName = tableName.TrimStart('@');
                table.TableDescription = description;
                table.TableType = type;
                table.Add();
            }
        }

        private void EnsureField(string table, string alias, string desc, BoFieldTypes type, int size = 0, BoFldSubTypes subType = BoFldSubTypes.st_None)
        {
            var uf = (UserFieldsMD)_company.GetBusinessObject(BoObjectTypes.oUserFields);
            if (!uf.GetByKey(table, alias))
            {
                uf.TableName = table;
                uf.Name = alias.Replace("U_", "");
                uf.Description = desc;
                uf.Type = type;
                uf.SubType = subType;
                if (size > 0) uf.Size = size;
                uf.Add();
            }
        }

        public void SaveLc(LetterOfCredit lc)
        {
            var ut = _company.UserTables.Item("TF_LC");
            ut.Code = lc.Code;
            ut.Name = lc.Name;
            ut.UserFields.Fields.Item("U_CardCode").Value = lc.CustomerCode;
            ut.UserFields.Fields.Item("U_Amount").Value = (double)lc.Amount;
            ut.UserFields.Fields.Item("U_Currency").Value = lc.Currency;
            ut.UserFields.Fields.Item("U_IssueDate").Value = lc.IssueDate;
            ut.UserFields.Fields.Item("U_ExpiryDate").Value = lc.ExpiryDate;
            ut.UserFields.Fields.Item("U_Status").Value = lc.Status;
            ut.Add();
        }

        public void SaveBg(BankGuarantee bg)
        {
            var ut = _company.UserTables.Item("TF_BG");
            ut.Code = bg.Code;
            ut.Name = bg.Name;
            ut.UserFields.Fields.Item("U_CardCode").Value = bg.VendorCode;
            ut.UserFields.Fields.Item("U_Amount").Value = (double)bg.Amount;
            ut.UserFields.Fields.Item("U_Currency").Value = bg.Currency;
            ut.UserFields.Fields.Item("U_IssueDate").Value = bg.IssueDate;
            ut.UserFields.Fields.Item("U_ExpiryDate").Value = bg.ExpiryDate;
            ut.UserFields.Fields.Item("U_Status").Value = bg.Status;
            ut.Add();
        }
    }
}
