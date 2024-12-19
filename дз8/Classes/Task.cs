using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using дз8.Enums;

namespace дз8.Classes
{
    public class Task
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Employee Initiator { get; set; }
        public Employee Implementer { get; set; }
        public TaskStatus Status { get; set; }
        public List<Report> Reports { get; set; }

        public Task(string description, DateTime deadline, Employee initiator)
        {
            Description = description;
            Deadline = deadline;
            Initiator = initiator;
            Status = TaskStatus.Назначена;
            Reports = new List<Report>();
        }
        public void StartWork(Employee implementer)
        {

            Implementer = implementer;
            Status = TaskStatus.Вработе;
        }

        public void DelegateTask(Employee newImplementer)
        {
            Implementer = newImplementer;
            Status = TaskStatus.Назначена;
        }

        public void RejectTask(object Task)
        {
            Implementer = null;
            Task = null;
        }
        public void AddReport(Report report)
        {
            Reports.Add(report);
        }
    }
}
