using GameOfLife.Model.GridModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model.Initialization
{
    public class RandomInitializationMethod : IInitializationMethod
    {
        private const int ALIVE_CHANCE = 20;
        private Random random = new Random();
        private Grid grid;

        public Grid Grid { set => grid = value; }

        public void InitCell(Cell cell, int x, int y)
        {
            cell.IsAlive = random.Next(1, 100) < ALIVE_CHANCE;
        }
    }
}
