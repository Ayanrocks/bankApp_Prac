using System;
namespace BankApp
{
    public struct TransactionType
    {
        public string name { set; get; }
        public Int64 transactionAmount { set; get; }
    }

    class CardType
    {
        public string type;
        public string cardNum;
        public string status { get; set; }
        public string expiryDate;
        public string cvv;
        public string cardProvider;
    }
}