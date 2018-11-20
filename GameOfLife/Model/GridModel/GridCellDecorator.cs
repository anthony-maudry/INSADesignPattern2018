using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model.GridModel
{
    public class GridCellDecorator : IGridCell
    {
        public Cell Cell { get; private set; }
        public Position Position { get; private set; }

        public GridCellDecorator(Cell cell, int x, int y)
        {
            Cell = cell;
            Position = new Position{ X = x, Y = y };
        }
    }
}
