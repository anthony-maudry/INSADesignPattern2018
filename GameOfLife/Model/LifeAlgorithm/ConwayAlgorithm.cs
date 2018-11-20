using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model.LifeAlgorithm
{
    public class ConwayAlgorithm : LifeAlgorithmBase
    {
        public override Cell GetCell(Grid grid, int x, int y)
        {
            var cell = grid.Cells[x, y];
            var nbAliveCells = GetSurroundingAliveCells(grid, x, y);

            Cell newCell;

            if (cell.IsAlive)
            {
                if (nbAliveCells <= 1 || nbAliveCells >= 4)
                {
                    newCell = new Cell { IsAlive = false };
                }
                else
                {
                    newCell = new Cell { IsAlive = true };
                }
            }
            else
            {
                if (nbAliveCells == 3)
                {
                    newCell = new Cell { IsAlive = true };
                }
                else
                {
                    newCell = new Cell { IsAlive = false };
                }
            }

            return newCell;
        }
    }
}
