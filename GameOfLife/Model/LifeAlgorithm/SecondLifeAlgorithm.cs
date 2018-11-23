using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model.LifeAlgorithm
{
    class SecondLifeAlgorithm : LifeAlgorithmBase, ILifeAlgorithm
    {
        public override Cell GetCell(Grid grid, int x, int y)
        {
            var newCell = new Cell();
            var alive = GetSurroundingAliveCells(grid, x, y);
            if (grid.Cells[x, y].IsAlive)
            {
                if (alive == 0)
                {
                    newCell.IsAlive = false;
                }
                else if (alive > 5)
                {
                    newCell.IsAlive = false;
                }
                else
                {
                    newCell.IsAlive = true;
                }
            }
            else
            {
                if (alive >= 2)
                {
                    newCell.IsAlive = true;
                }
                else
                {
                    newCell.IsAlive = false;
                }
            }

            return newCell;
        }
    }
}
