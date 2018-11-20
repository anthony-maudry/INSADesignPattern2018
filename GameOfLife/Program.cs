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
            Console.WriteLine("Welcome on board !");
            var userConfig = new UserConfiguration();

            userConfig.GridWidth = ReadNumericalValue("Enter the width of the grid in number of cells (min 50, max 1000) :", 50, 1000);
            userConfig.GridHeight = ReadNumericalValue("Enter the height of the grid in number of cells (min 50, max 1000) :", 50, 1000);

            Console.WriteLine("Here is the initialization types possible :");
            Console.WriteLine("1. Random");
            Console.WriteLine("2. Chessboard");
            Console.WriteLine("3. Model file");
            switch (ReadNumericalValue("Choose the number of the desired initialization method :", 1, 3))
            {
                case 1:
                    userConfig.InitializationMethod = new RandomInitializationMethod();
                    break;
                case 2:
                    userConfig.InitializationMethod = new ChessBoardInitializationMethod();
                    break;
                case 3:
                    Console.WriteLine("Possible models :");
                    Console.WriteLine("1. Rabbit");
                    Console.WriteLine("2. Arrow");
                    var modelIndex = ReadNumericalValue("Enter the number of the desired model :", 1, 2);
                    string model = "point";
                    switch (modelIndex)
                    {
                        case 1:
                            model = "rabbit";
                            break;
                        case 2:
                            model = "arrow";
                            break;
                    }
                    userConfig.InitializationMethod = new ModelFileInitialization(model);
                    break;
            }

            Console.WriteLine("Here is the available algorithmes :");
            Console.WriteLine("1. Exercise first algo");
            Console.WriteLine("2. Conway game of life algo");
            switch (ReadNumericalValue("Choose the number of the desired initialization method :", 1, 2))
            {
                case 1:
                    userConfig.LifeAlgorithm = new FirstLifeAlgorithm();
                    break;
                case 2:
                    userConfig.LifeAlgorithm = new ConwayAlgorithm();
                    break;
            }

            userConfig.MillisecondsBetweenFrames = ReadNumericalValue("Enter the desired number of milliseconds between frames (min 10, max 5000) :", 10, 5000);

            Console.WriteLine("Press [enter] to start");
            Console.ReadLine();
            var window = new WindowView(userConfig);
            window.Run();
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
