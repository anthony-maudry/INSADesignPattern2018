using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model.Initialization
{
    public class ModelFileInitialization : IInitializationMethod
    {
        private readonly string[] lines;
        private readonly int longuest;
        public ModelFileInitialization(string model)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"Data/Models/{model}.txt");
            lines = File.ReadAllLines(path);

            var longuest = 0;

            foreach(var line in lines)
            {
                if (line.Length > longuest)
                {
                    longuest = line.Length;
                }
            }

            this.longuest = longuest;
        }

        public Grid Grid { get; set; }

        public void InitCell(Cell cell, int x, int y)
        {
            int offsetX = (Grid.Width - longuest) / 2;
            int offsetY = (Grid.Height - lines.Length) / 2;

            int charNumber = x - offsetX;
            int lineNumber = y - offsetY;

            bool alive = false;

            if (charNumber < 0 || lineNumber < 0 || lineNumber >= lines.Length)
            {
                alive = false;
            }
            else if (charNumber >= lines[lineNumber].Length)
            {
                alive = false;
            }
            else
            {
                alive = lines[lineNumber][charNumber] != ' ';
            }

            cell.IsAlive = alive;
        }
    }
}
