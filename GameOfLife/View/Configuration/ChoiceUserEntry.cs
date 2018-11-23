using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.View.Configuration
{
    public abstract class ChoiceUserEntry<TEntry> : UserEntryBase where TEntry : class
    {

        public List<AvailableEntry<TEntry>> AvailableEntries { get; set; }

        protected string QuestionTitle = "";

        public TEntry Run()
        {
            MakeQuestion();
            var value = AskValue();

            foreach(var entry in AvailableEntries)
            {
                if (value == entry.Index)
                {
                    return entry.Value;
                }
            }

            Console.WriteLine($"{value} is not a valid entry");

            return null;
        }

        private void MakeQuestion()
        {
            string display = QuestionTitle;
            foreach (var entry in AvailableEntries)
            {
                display += Environment.NewLine + $" - {entry.Index} - {entry.Label}";
            }

            Question = display;
        }
    }
}
