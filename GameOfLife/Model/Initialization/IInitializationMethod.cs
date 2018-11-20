using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model.Initialization
{
    public interface IInitializationMethod
    {
        Grid Grid { set; }
        void InitCell(Cell cell, int x, int y);
    }
}
