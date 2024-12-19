using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace тумаков.Classes
{
    public enum AccountType
    {
        текущий,
        накопительный
    }
    internal class BankAccount : IDisposable
    {
        public static Random random = new Random();
        public string accountNumber;
        public decimal balance;
        public AccountType accountType;
        private readonly Queue<BankTransaction> transactions;
        private bool disposed = false;
        public BankAccount()
        {
            accountNumber = GenerateAccountNumber();
            balance = 0;
            accountType = AccountType.текущий; 
            transactions = new Queue<BankTransaction>();
        }
        // конструктор для заполнения баланса
        public BankAccount(decimal balance)
        {
            accountNumber = GenerateAccountNumber();
            this.balance = balance;
            accountType = AccountType.текущий;
            transactions = new Queue<BankTransaction>();
        }
        // конструктор для заполнения поля типа
        public BankAccount(AccountType accountType)
        {
            accountNumber = GenerateAccountNumber();
            balance = 0; 
            this.accountType = accountType;
            transactions = new Queue<BankTransaction>();
        }
        // конструктор для заполнения баланса и типа 
        public BankAccount(decimal balance, AccountType accountType)
        {
            accountNumber = GenerateAccountNumber();
            this.balance = balance;
            this.accountType = accountType;
            transactions = new Queue<BankTransaction>();
        }
        public string GenerateAccountNumber()
        {
            long accountNumber = random.Next(10000000, 99999999);
            return accountNumber.ToString();
        }
        public string GetAccountInfo()
        {
            return $"Номер счета: {accountNumber}, Баланс: {balance}, Тип счета: {accountType}";
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException("Сумма должна быть положительной");
            balance += amount;
            transactions.Enqueue(new BankTransaction(amount));
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException("Сумма должна быть положительной.");

            if (amount > balance)
                throw new InvalidOperationException("Недостаточно средств для снятия.");

            balance -= amount;
            transactions.Enqueue(new BankTransaction(-amount));
        }
        public Queue<BankTransaction> GetTransactionHistory()
        {
            return transactions;
        }
        public void ShowTransactionHistory()
        {
            Console.WriteLine("История транзакций:");
            foreach (var transaction in GetTransactionHistory())
            {
                Console.WriteLine($"Номер счета: {accountNumber}, Сумма: {transaction.Amount}, Дата транзакции: {transaction.TransactionDate}");
            }
        }
        private void WriteToFile()
        {
            using (StreamWriter writer = new StreamWriter("transactions.txt", true))
            {
                foreach (var transaction in transactions)
                {
                    writer.WriteLine($"Дата: {transaction.TransactionDate}, Сумма: {transaction.Amount}");
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    WriteToFile();
                }
                disposed = true;
            }
        }
    }
}

