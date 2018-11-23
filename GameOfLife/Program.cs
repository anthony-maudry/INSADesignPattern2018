using GameOfLife.GameConfiguration;
using GameOfLife.Model.Initialization;
using GameOfLife.Model.LifeAlgorithm;
using GameOfLife.View;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {

        static void Main()
        {
            var goOn = true;
            var userConfiguration = new UserConfiguration();
                
            do
            {
                new ConfigurationView(userConfiguration).Run();

                Console.WriteLine("Press [enter] to start");
                Console.ReadLine();
                var window = new WindowView(userConfiguration);

                window.Run();

                char answer;

                do
                {
                    Console.WriteLine("Another try ? (y/n/yes/no)");
                    answer = Console.ReadLine().ToLower()[0];
                    goOn = answer == 'y';
                } while (answer != 'y' && answer != 'n');
            } while (goOn);

        } //End Main()

        private static int ReadNumericalValue(string question, int minValue = 0, int maxValue = 1000, string help = null)
        {
            do
            {
                Console.WriteLine(question);

                if (help != null)
                {
                    Console.WriteLine("Type 'h' or 'help' for a help about that entry");
                }

                string strWidth = Console.ReadLine();

                if (help != null && (strWidth == "help" || strWidth == "h"))
                {
                    foreach (var line in help.Split('\n'))
                    {
                        Console.WriteLine(line);
                    }
                }
                else if (!strWidth.All(char.IsDigit))
                {
                    Console.WriteLine("Sorry, not a valid number !");
                }
                else
                {
                    int.TryParse(strWidth, out int width);

                    if (width < minValue || width > maxValue)
                    {
                        Console.WriteLine($"Number should be between {minValue} and {maxValue}");
                    }
                    else
                    {
                        return width;
                    }
                }
            } while (true);
        }


    } //End Program

}
