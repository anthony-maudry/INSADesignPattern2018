using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Model.Initialization;
using GameOfLife.Model.LifeAlgorithm;

namespace GameOfLife.GameConfiguration
{
    public class SimpleGameConfiguration : IGameConfiguration
    {
        public int MillisecondsBetweenFrames => 500;

        public ILifeAlgorithm LifeAlgorithm => new FirstLifeAlgorithm();

        public IInitializationMethod InitializationMethod => new RandomInitializationMethod();

        public int GridWidth => 150;

        public int GridHeight => 150;
    }
}
