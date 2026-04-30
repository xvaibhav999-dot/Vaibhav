using System;

namespace SapB1TradeFinanceAddon.Data
{
    public class LetterOfCredit
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string CustomerCode { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Status { get; set; }
    }

    public class BankGuarantee
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string VendorCode { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Status { get; set; }
    }
}
