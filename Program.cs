using System;
using System.Collections.Generic;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Banking App!");
            var customer = new Bank(20000, "Ayan Banerjee", "Savings");
            while (true)
            {
                System.Console.WriteLine($"\nHello, {customer.AccountHolderName}\t\t\t\t\t\t\t\tBalance: {customer.accountBalance}\n");
                System.Console.WriteLine($"Currently Issued Card Details:\n");
                System.Console.WriteLine($"Card Number:\t\t{customer.currentCard.cardNum}");
                System.Console.WriteLine($"Card Expiry Date:\t\t{customer.currentCard.expiryDate}");
                System.Console.WriteLine($"Card CVV:\t\t{customer.currentCard.cvv}");
                System.Console.WriteLine($"Card Type:\t\t{customer.currentCard.type}");
                System.Console.WriteLine($"Card Provider:\t\t{customer.currentCard.cardProvider}");
                System.Console.WriteLine("Here are your banking options(Press 'q' or 'Q' to exit): \n     1.\t View Available Cards\n     2.\t View Transactions\n     3.\t View Currently Issued Card\n     4.\t Deposit Cash\n     5.\t Withdraw Cash\n     6.\t Issue A New Card\n     7.\t Clear Screen\n");
                System.Console.WriteLine("Enter Your Choice: ");
                var choice = Console.ReadLine();

                if (choice == "q" || choice == "Q")
                {
                    System.Console.WriteLine("Thanks for banking with us.");
                    break;
                }
                switch (choice)
                {

                    case "1":
                        PrintCards(customer.cards);
                        break;
                    case "2":
                        PrintTxn(customer.transactions);
                        break;
                    case "3":
                        System.Console.WriteLine($"Currently Issued Card Details:\n");
                        System.Console.WriteLine($"\n==================================\n");
                        System.Console.WriteLine($"Card Number:\t\t{customer.currentCard.cardNum}");
                        System.Console.WriteLine($"Card Expiry Date:\t\t{customer.currentCard.expiryDate}");
                        System.Console.WriteLine($"Card CVV:\t\t{customer.currentCard.cvv}");
                        System.Console.WriteLine($"Card Type:\t\t{customer.currentCard.type}");
                        System.Console.WriteLine($"Card Provider:\t\t{customer.currentCard.cardProvider}");
                        System.Console.WriteLine($"\n==================================\n");
                        break;
                    case "4":
                        System.Console.WriteLine("Enter Amount to Deposit: ");
                        int amount = int.Parse(Console.ReadLine());
                        customer.Deposit(amount);
                        break;
                    case "5":
                        customer.Withdrawl();
                        break;
                    case "6":
                        customer.issueNewCard();
                        break;
                    case "7":
                        Console.Clear();
                        break;
                    default:
                        System.Console.WriteLine("Wrong Choice!. Try Again");
                        break;
                }
                // Console.Clear();
            }
        }

        public static void PrintCards(List<CardType> cards)
        {
            System.Console.WriteLine("\nHere are your available Cards: \n");
            foreach (var card in cards)
            {
                System.Console.WriteLine($"Card Number:\t\t{card.cardNum}");
                System.Console.WriteLine($"Card Expiry Date:\t\t{card.expiryDate}");
                System.Console.WriteLine($"Card CVV:\t\t{card.cvv}");
                System.Console.WriteLine($"Card Type:\t\t{card.type}");
                System.Console.WriteLine($"Card Provider:\t\t{card.cardProvider}");
            }
        }

        public static void PrintTxn(List<TransactionType> txn)
        {
            System.Console.WriteLine("\nHere are your Transactions: \n");
            foreach (var tx in txn)
            {
                System.Console.WriteLine($"{tx.name}");
                System.Console.WriteLine($"Transaction Amount:\t\t{tx.transactionAmount}");
            }
        }
    }
}
