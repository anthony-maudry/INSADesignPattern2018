using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model.Initialization
{
    public class ChessBoardInitializationMethod : IInitializationMethod
    {
        public Grid Grid { get; set; }

        public void InitCell(Cell cell, int x, int y)
        {
            cell.IsAlive = ((x + y) % 2) == 0;
        }
    }
}
