using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model.LifeAlgorithm
{
    public interface ILifeAlgorithm
    {
        Grid Apply(Grid grid);

        Cell GetCell(Grid gris, int x, int y);
    }
}
