using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model.GridModel
{
    public interface IGridCell
    {
        Cell Cell { get; }
        Position Position { get; }
    }
}
