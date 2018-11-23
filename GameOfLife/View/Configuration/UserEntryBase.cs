using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.View.Configuration
{
    public abstract class UserEntryBase : ConfigurationPartialViewBase
    {
        public string Question { get; set; }
        public string Help { get; set; }
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }

        protected int? AskValue()
        {
            foreach (var line in Question.Split(Environment.NewLine[0]))
            {
                Console.WriteLine(line.Replace("\n", ""));
            }

            if (Help != null && Help != "")
            {
                Console.WriteLine("Type h/help to get some help.");
            }

            var result = Console.ReadLine().ToLower();

            if (result.Length == 0)
            {
                return null;
            }

            if (result.Length > 0 && result[0] == 'h')
            {
                foreach (var line in Help.Split(Environment.NewLine[0]))
                {
                    Console.WriteLine(line.Replace("\n", ""));
                    result = Console.ReadLine();
                }
            }

            if (!result.All(char.IsDigit))
            {
                Console.WriteLine("Sorry, invalid entry. Please enter a number.");
            }
            else
            {
                int.TryParse(result, out int value);

                if (MinValue != null && value < MinValue)
                {
                    Console.WriteLine($"Sorry, value must be at least {MinValue}");
                }

                if (MaxValue != null && value > MaxValue)
                {
                    Console.WriteLine($"Sorry, value must be at most {MaxValue}");
                }

                return value;
            }

            return null;
        }
    }
}
