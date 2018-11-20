using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model.LifeAlgorithm
{
    public class FirstLifeAlgorithm : LifeAlgorithmBase
    {
        public override Cell GetCell(Grid grid, int x, int y)
        {
            var cell = grid.Cells[x, y];
            var nbAliveCells = GetSurroundingAliveCells(grid, x, y);

            Cell newCell;

            if (nbAliveCells < 3 && nbAliveCells > 0)
            {
                newCell = new Cell { IsAlive = true };
            }
            else if (nbAliveCells == 0 || nbAliveCells > 5)
            {
                newCell = new Cell { IsAlive = false };
            }
            else
            {
                newCell = new Cell { IsAlive = cell.IsAlive };
            }

            return newCell;
        }
    }
}
