using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using тумаков.Classes;

namespace тумаков
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Song mySong = new Song();
        }
        static void Task1()
        {
            Console.WriteLine("Упражнение 9.1");
            
            /*В классе банковский счет, созданном в предыдущих упражнениях, удалить
             методы заполнения полей. Вместо этих методов создать конструкторы. Переопределить
             конструктор по умолчанию, создать конструктор для заполнения поля баланс, конструктор
             для заполнения поля тип банковского счета, конструктор для заполнения баланса и типа
             банковского счета. Каждый конструктор должен вызывать метод, генерирующий номер
             счета*/

            BankAccount account1 = new BankAccount();
            BankAccount account2 = new BankAccount(11000.50m);
            BankAccount account3 = new BankAccount(AccountType.накопительный);
            BankAccount account4 = new BankAccount(25100.75m, AccountType.накопительный);

            Console.WriteLine(account1.GetAccountInfo());
            Console.WriteLine(account2.GetAccountInfo());
            Console.WriteLine(account3.GetAccountInfo());
            Console.WriteLine(account4.GetAccountInfo());
        }

        static void Task2()
        {
            Console.WriteLine("Упражнение 9.2");

            /*Создать новый класс BankTransaction, который будет хранить информацию
             о всех банковских операциях. При изменении баланса счета создается новый объект класса
             BankTransaction, который содержит текущую дату и время, добавленную или снятую со
             счета сумму. Поля класса должны быть только для чтения (readonly). Конструктору класса
             передается один параметр–сумма. В классе банковский счет добавить закрытое поле типа
             System.Collections.Queue, которое будет хранить объекты класса BankTransaction для
             данного банковского счета; изменить методы снятия со счета и добавления на счет так,
             чтобы в них создавался объект класса BankTransaction и каждый объект добавлялся в
             переменную типа System.Collections.Queue*/

            BankAccount account1 = new BankAccount(12345);
            BankAccount account2 = new BankAccount(98765);
            Console.WriteLine(account1.GetAccountInfo());
            Console.WriteLine(account2.GetAccountInfo());
            account1.Deposit(124);
            account2.Withdraw(421);
            account1.ShowTransactionHistory();
            account2.ShowTransactionHistory();
        }

        static void Task3()
        {
            Console.WriteLine("Упражнение 9.3");

            /*В классе банковский счет создать метод Dispose, который данные о
             проводках из очереди запишет в файл. Не забудьте внутри метода Dispose вызвать метод
             GC.SuppressFinalize, который сообщает системе, что она не должна вызывать метод
             завершения для указанного объекта.*/

            using (BankAccount account = new BankAccount(1234m))
            {
                Console.WriteLine(account.GetAccountInfo());
                account.Deposit(200); 
                account.Withdraw(100); 
                foreach (var transaction in account.GetTransactionHistory())
                {
                    Console.WriteLine($"Дата: {transaction.TransactionDate}, Сумма: {transaction.Amount}");
                }
            } 
            Console.WriteLine("Все транзакции записаны в файл transactions.txt");
        }

        static void Task4()
        {
            Console.WriteLine("Домашнее задание 9.1");

            /* В класс Song (из домашнего задания 8.2) добавить следующие
             конструкторы:
             1) параметры конструктора– название и автор песни, указатель на предыдущую песню
             инициализировать null.
             2) параметры конструктора– название, автор песни, предыдущая песня. В методе Main
             создать объект mySong. Возникнет ли ошибка при инициализации объекта mySong
             следующим образом: Song mySong = new Song(); ?
             Исправьте ошибку, создав необходимый конструктор*/

            List<Song> songs = new List<Song>
            {
                new Song ( "Yummy", "Justin Bieber" ),
                new Song ( "dance floor", "newlightchild" ),
                new Song ( "riptide", "Vance Joy" ),
                new Song ( "blank space", "Taylor Swift" )
            };
            songs.Add(new Song("Let It Snow", "Frank Sinatra", songs[1]));
            for (int i = 1; i < songs.Count; i++)
            {
                songs[i].FillPrevSong(songs[i - 1]);
            }
            foreach (Song song in songs)
            {
                Console.WriteLine(song.Title());
            }
            bool areEqual = songs[0].Equals(songs[1]);
            Console.WriteLine("Первая и вторая песни равны: " + areEqual);
        }
    }
}
