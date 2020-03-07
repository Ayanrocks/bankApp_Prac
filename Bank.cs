using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp
{
    class Bank
    {
        public int accountBalance { get; private set; }
        public string accountType { get; private set; }
        public string accountNumber { get; private set; }
        public string AccountHolderName { get; private set; }
        public List<CardType> cards { get; private set; } = new List<CardType>();
        public CardType currentCard { get; private set; } = new CardType();
        public List<TransactionType> transactions = new List<TransactionType>();

        public Bank(int accountBalance, string AccountHolderName, string accountType = "Savings")
        {
            if (accountBalance < 20000)
            {
                throw new Exception("Minimum Balance Required is 20000");

            }
            else
            {
                // System.Console.Clear();
                this.AccountHolderName = AccountHolderName;
                var randomList = new List<string>();
                Random generator = new Random();
                for (int i = 0; i < 8; i++)
                {
                    String r = generator.Next(0, 99).ToString("D2");
                    randomList.Add(r);
                }
                this.accountNumber = String.Join("", randomList);
                this.accountBalance = accountBalance;
                this.accountType = accountType;
                this.IssueCard("Debit", "MasterCard");
                System.Console.WriteLine("Thanks for opening your account with us");
            }

        }

        public int Withdrawl()
        {
            System.Console.WriteLine("Enter the amount you want to Withdraw");
            var amount = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter your Card Details: \nCard Number:\t\t");
            var cardNum = Console.ReadLine();
            System.Console.WriteLine("\nEnter PIN/CVV:\t\t");
            var cvv = Console.ReadLine();
            if (this.currentCard.cardNum == cardNum && this.currentCard.cvv == cvv)
            {
                this.accountBalance -= amount;
                this.GenReceipt(amount, $"xxxxxxxxxxxx{this.currentCard.cardNum.Substring(this.currentCard.cardNum.Length - 4)} Withdrawl");
                return amount;
            }
            System.Console.WriteLine("Wrong Pin or CardNum. Please try again ");
            return -1;

        }

        public string Deposit(int amount)
        {
            this.accountBalance += amount;

            return this.GenReceipt(amount, "Deposit");
        }

        public string GenReceipt(int amount, string name, string cardNum = "")
        {
            var GenReceipt = $"=====================\nTransaction Details: \n Name: \t\t POS {cardNum} in {name} \n Amount: \tINR {amount} /-===========";
            this.CreateTxn(GenReceipt, amount);
            return GenReceipt;
        }

        public void CreateTxn(string txnReceipt, int amount)
        {
            TransactionType txn = new TransactionType();
            txn.name = txnReceipt;
            txn.transactionAmount = amount;

            this.transactions.Add(txn);
        }

        public void IssueCard(string type, string provider = "MasterCard")
        {
            var randomList = new List<string>();
            Random generator = new Random();
            for (int i = 0; i < 8; i++)
            {
                String r = generator.Next(0, 99).ToString("D2");
                randomList.Add(r);
            }
            var cardNum = String.Join("", randomList);
            var expiryDate = $"{generator.Next(0, 12).ToString("D2")} / {generator.Next(21, 28).ToString("D2")}";
            var cvv = $"{generator.Next(100, 999).ToString("D3")}";
            var cardType = new CardType();
            cardType.cardNum = cardNum;
            cardType.type = type;
            cardType.status = "Active";
            cardType.expiryDate = expiryDate;
            cardType.cvv = cvv;
            cardType.cardProvider = provider;
            this.currentCard = cardType;
            this.cards.Add(cardType);
            this.DeactivateOldCard(type);
            System.Console.WriteLine($"Your newly issued card has following details:\n CardNum:\t\t{cardNum} \n Expiry:\t\t{expiryDate}\n CVV:\t\t\t{cvv}\n\n==========PLEASE DONOT SHARE YOUR CARD DETAILS WITH ANYONE!!!=========");

        }

        public void issueNewCard()
        {
            System.Console.WriteLine("Welcome to issuing your new card");
            System.Console.WriteLine("Select your card type below:\n0.\t\tDebit\n1.\t\tCredit");
            var ctype = Console.ReadLine();
            if (ctype == "0")
            {
                ctype = "Debit";
            }
            else if (ctype == "1")
            {
                ctype = "Credit";
            }
            System.Console.WriteLine("Enter your card Provider:\n0.\t\tVisa\n1.\t\tMasterCard\n2.\t\tRupay");
            var cProvdr = Console.ReadLine();
            if (cProvdr == "0")
            {
                cProvdr = "Visa";
            }
            else if (cProvdr == "1")
            {
                cProvdr = "MasterCard";
            }
            else if (cProvdr == "2")
            {
                cProvdr = "Rupay";
            }
            this.IssueCard(ctype, cProvdr);

        }

        private void DeactivateOldCard(string type)
        {
            if (this.cards.Count > 1)
            {
                // var linqQuery = from card in this.cards
                //                 where card.type == "Debit"
                //                 select card;
                for (int i = 0; i < this.cards.Count; i++)
                {
                    if (this.cards[i].status == type)
                    {
                        this.cards[i].status = "Hotlisted";
                    }
                }
            }
        }
    }

}
