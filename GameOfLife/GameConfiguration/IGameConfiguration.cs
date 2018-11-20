using GameOfLife.Model.Initialization;
using GameOfLife.Model.LifeAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.GameConfiguration
{
    public interface IGameConfiguration
    {
        int MillisecondsBetweenFrames { get; }
        ILifeAlgorithm LifeAlgorithm { get; }
        IInitializationMethod InitializationMethod { get; }
        int GridWidth { get; }
        int GridHeight { get; }
    }
}
