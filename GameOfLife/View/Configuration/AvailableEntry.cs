using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.View.Configuration
{
    public class AvailableEntry<TValue> where TValue : class
    {
        public TValue Value { get; set; }
        public string Label { get; set; }
        public int Index { get; set; }
    }
}
