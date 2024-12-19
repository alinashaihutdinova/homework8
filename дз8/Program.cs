using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using дз8.Classes;

namespace дз8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("задание про манагера");
            
            Employee order = new Employee("Алина");
            Employee teamlead = new Employee("Зарина");
            Employee Dariya = new Employee("Дарья");
            Employee Dilyara = new Employee("Диляра");
            Employee Andrey = new Employee("Андрей");
            Employee Kamil = new Employee("Камиль");
            Employee Dana = new Employee("Дана");
            Employee Arina = new Employee("Арина");
            Employee Aliya = new Employee("Алия");
            Employee Daliya = new Employee("Далия");
            Employee Michail = new Employee("Михаил");
            Employee Sergey = new Employee("Сергей");
            Project project = new Project("Создание нового приложения", DateTime.Now.AddMonths(2), order, teamlead);
            
            /*project.AddTask("Разработка дизайна", Arina);
            project.AddTask("вапр", Kamil);
            project.AddTask("Тывапр", Dana);
            project.AddTask("ывапр", Sergey);
            project.AddTask("цукенго", Andrey);
            project.AddTask("длорпа", Dariya);
            project.AddTask("ывапр", Dilyara);
            project.AddTask("ывапро", Daliya);
            project.AddTask("ывапро", Aliya);
            project.AddTask("ывапро", Michail);*/
            
        }
    }
}
