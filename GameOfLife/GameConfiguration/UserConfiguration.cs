using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Model.Initialization;
using GameOfLife.Model.LifeAlgorithm;

namespace GameOfLife.GameConfiguration
{
    public class UserConfiguration : IGameConfiguration
    {
        public int MillisecondsBetweenFrames { get; set; }

        public ILifeAlgorithm LifeAlgorithm { get; set; }

        public IInitializationMethod InitializationMethod { get; set; }

        public int GridWidth { get; set; }

        public int GridHeight { get; set; }
    }
}
