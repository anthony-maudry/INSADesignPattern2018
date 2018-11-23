using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.View.Configuration
{
    public abstract class NumericalUserEntry : UserEntryBase
    {
        public int? Run()
        {
            return AskValue();
        }
    }

}
