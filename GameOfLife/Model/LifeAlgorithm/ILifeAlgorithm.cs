using GameOfLife.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model.LifeAlgorithm
{
    public interface ILifeAlgorithm
    {
        event EventHandler<AlgorithmEvent> OnStartedFrame;
        event EventHandler<AlgorithmEvent> OnEndedFrame;
        event EventHandler<AlgorithmEvent> OnStabilized;
        event EventHandler<AlgorithmEvent> OnSterilized;
        event EventHandler<AlgorithmEvent> OnOverCrowded;

        Grid Apply(Grid grid);

        Cell GetCell(Grid gris, int x, int y);
    }
}
