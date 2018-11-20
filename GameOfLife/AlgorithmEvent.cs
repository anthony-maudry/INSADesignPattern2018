using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Events
{
    public enum AlgorithmEventKind { None, StartedFrame, EndedFrame, Stabilized, Sterilized, OverCrowded }

    public class AlgorithmEvent : EventArgs
    {
        public AlgorithmEventKind Event { get; private set; }

        public AlgorithmEvent(AlgorithmEventKind algorithmEvent) : base()
        {
            Event = algorithmEvent;
        }
    }
}
