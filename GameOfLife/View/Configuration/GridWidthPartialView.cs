using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.View.Configuration
{
    public class GridWidthPartialView : NumericalUserEntry
    {
        private const int MIN_VALUE = 10;
        private const int MAX_VALUE = 1000;

        public GridWidthPartialView()
        {
            Question = "Enter the width of the grid (min 10 - max 1000) :";
            Help = "Type a number between 10 and 1000 and press [enter]";
            MinValue = MIN_VALUE;
            MaxValue = MAX_VALUE;
        }

        public override void RunPartial()
        {
            int? value = null;
            do
            {
                value = Run();
            } while (value == null);

            userConfiguration.GridWidth = value ?? MIN_VALUE;
        }
    }
}
