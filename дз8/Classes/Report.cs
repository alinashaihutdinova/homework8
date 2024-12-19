using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace дз8.Classes
{
    public class Report
    {
        public string Text { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Implementer { get; set; }

        public Report(string text, DateTime completionDate, string implementer)
        {
            Text = text;
            CompletionDate = completionDate;
            Implementer = implementer;
        }
    }
}
