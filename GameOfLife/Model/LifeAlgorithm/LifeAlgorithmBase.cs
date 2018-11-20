using GameOfLife.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model.LifeAlgorithm
{
    public abstract class LifeAlgorithmBase : ILifeAlgorithm
    {
        public event EventHandler<AlgorithmEvent> OnStartedFrame;
        public event EventHandler<AlgorithmEvent> OnEndedFrame;
        public event EventHandler<AlgorithmEvent> OnStabilized;
        public event EventHandler<AlgorithmEvent> OnSterilized;
        public event EventHandler<AlgorithmEvent> OnOverCrowded;

        public Grid Apply(Grid grid)
        {
            var newGrid = (Grid)grid.Clone();

            var i = 0;

            OnStartedFrame?.Invoke(this, new AlgorithmEvent(AlgorithmEventKind.StartedFrame));

            bool changed = false;
            int countAlive = 0;

            for (var x = 0; x < grid.Width; x++)
            {
                for (var y = 0; y < grid.Height; y++)
                {

                    var newCell = GetCell(grid, x, y);

                    newGrid.AddCell(newCell, x, y);

                    countAlive += newCell.IsAlive ? 1 : 0;

                    if (!changed && newCell.IsAlive != grid.Cells[x,y].IsAlive)
                    {
                        changed = true;
                    }

                    i++;
                }
            }

            if (!changed)
            {
                OnStabilized?.Invoke(this, new AlgorithmEvent(AlgorithmEventKind.Stabilized));
            }

            if (countAlive == 0)
            {
                OnSterilized?.Invoke(this, new AlgorithmEvent(AlgorithmEventKind.Sterilized));
            }

            if(countAlive == grid.Width * grid.Height)
            {
                OnOverCrowded?.Invoke(this, new AlgorithmEvent(AlgorithmEventKind.OverCrowded));
            }

            OnEndedFrame?.Invoke(this, new AlgorithmEvent(AlgorithmEventKind.EndedFrame));

            return newGrid;
        }

        public abstract Cell GetCell(Grid grid, int x, int y);

        protected int GetSurroundingAliveCells(Grid grid, int x, int y)
        {
            var nbAlive = 0;
            for (var i = x - 1; i <= x + 1; i++)
            {
                for (var j = y - 1; j <= y + 1; j++)
                {
                    if (
                        i >= 0 && j >= 0 &&
                        i < grid.Width && j < grid.Height &&
                        (i != 0 || j != 0) &&
                        grid.Cells[i, j].IsAlive
                    )
                    {
                        nbAlive++;
                    }
                }
            }

            return nbAlive;
        }
    }
}
