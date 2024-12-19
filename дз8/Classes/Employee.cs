using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace дз8.Classes
{
    public class Employee
    {
        public string Name { get; private set; }
        public Employee(string name)
        {
            Name = name;
        }
    }
}
