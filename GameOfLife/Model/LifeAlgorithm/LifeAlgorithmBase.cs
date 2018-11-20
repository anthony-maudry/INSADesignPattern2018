using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model.LifeAlgorithm
{
    public abstract class LifeAlgorithmBase : ILifeAlgorithm
    {
        public Grid Apply(Grid grid)
        {
            var newGrid = (Grid)grid.Clone();

            var i = 0;

            var totalStart = DateTime.Now;
            var Started = DateTime.Now;
            for (var x = 0; x < grid.Width; x++)
            {
                for (var y = 0; y < grid.Height; y++)
                {

                    var newCell = GetCell(grid, x, y);

                    newGrid.AddCell(newCell, x, y);

                    i++;
                }
            }

            return newGrid;
        }

        public abstract Cell GetCell(Grid grid, int x, int y);

        protected int GetSurroundingAliveCells(Grid grid, int x, int y)
        {
            var nbAlive = 0;
            for (var i = x - 1; i <= x + 1; i++)
            {
                for (var j = y - 1; j <= y + 1; j++)
                {
                    if (
                        i >= 0 && j >= 0 &&
                        i < grid.Width && j < grid.Height &&
                        (i != 0 || j != 0) &&
                        grid.Cells[i, j].IsAlive
                    )
                    {
                        nbAlive++;
                    }
                }
            }

            return nbAlive;
        }
    }
}
