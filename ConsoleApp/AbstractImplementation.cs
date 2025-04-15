using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public abstract class Account
    {
        public string AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        protected Account(string accountNumber, string accountHolder)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = 0;
            AccountType = GetType().Name;
        }
        public void Deposit(decimal amount) { Balance += amount; }
        public abstract void Withdraw(decimal amount);
        public virtual void DisplayDetails()
        {
            Console.WriteLine(
                $"Account Number: {AccountNumber}, Holder: {AccountHolder}, Balance: {Balance}, Account Type: {AccountType}");
        }
    }
    public class Savings : Account
    {
        public Savings(
            string accountNumber,
            string accountHolder)
            : base(accountNumber, accountHolder)
        {
        }
        public override void Withdraw(decimal amount)
        {
            if ((Balance - amount) < 5000)
            {
                Console.WriteLine("Insufficient funds.");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawn: {amount}, New Balance: {Balance}");
            }
        }
    }
    public class Current : Account
    {
        public Current(
            string accountNumber,
            string accountHolder)
            : base(accountNumber, accountHolder)
        {
        }
        public override void Withdraw(decimal amount)
        {
            if ((Balance - amount) < 10000)
            {
                Console.WriteLine("Insufficient funds.");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawn: {amount}, New Balance: {Balance}");
            }
        }

    }

    public class AbstractImplementation
    {
        public static void Test()
        {
            // Account acc = new Account("123456", "John Doe"); 
            // Cannot create an instance of the abstract class
            Account acc = new Savings("123456", "John Doe");
            acc.DisplayDetails();
            acc.Deposit(10000);
            acc.DisplayDetails();
            acc.Withdraw(6000);
            acc.DisplayDetails();
            acc.Withdraw(4000);
            acc.DisplayDetails();
        }
    }

}
