using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.View.Configuration
{
    public class FrameRateEntry : NumericalUserEntry
    {
        private const int MIN_VALUE = 10;

        public FrameRateEntry()
        {
            Question = "How many miliseconds will be spent between each frame (algo pass)";
            Help = "This will determine the time between each pass of the algo" + Environment.NewLine +
                "and therefore each window refresh";
            MinValue = MIN_VALUE;
        }

        public override void RunPartial()
        {
            int? ms;

            do
            {
                ms = Run();
            } while (ms == null);

            userConfiguration.MillisecondsBetweenFrames = ms ?? MIN_VALUE;
        }
    }
}
