using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using дз8.Enums;

namespace дз8.Classes
{
    public class Project
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Employee Order { get; set; }
        public Employee TeamLead { get; set; }
        public List<Task> Tasks { get; set; }
        public ProjectStatus Status { get; set; }

        public Project(string description, DateTime deadline, Employee order, Employee teamLead)
        {
            Description = description;
            Deadline = deadline;
            Order = order;
            TeamLead = teamLead;
            Tasks = new List<Task>();
            Status = ProjectStatus.Проект;
        }
        public void AddTask(Task task)
        {
            if (Status == ProjectStatus.Проект)
            {
                Tasks.Add(task);
            }
            else
            {
                Console.WriteLine("Невозможно добавить задачу, проект не в статусе <Проект>");
            }
        }
        public void StartProject()
        {
            if (Status == ProjectStatus.Проект)
            {
                Status = ProjectStatus.Исполение;
            }
        }
        public bool IsClosed()
        {
            foreach (var task in Tasks)
            {
                if (task.Status != TaskStatus.Выполнена)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
