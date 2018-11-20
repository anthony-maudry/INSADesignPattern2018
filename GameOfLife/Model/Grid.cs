using GameOfLife.Model.GridModel;
using GameOfLife.Model.Initialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model
{
    public class Grid : ICloneable
    {
        private IInitializationMethod initializationMethod;

        public int Width { get; set; }
        public int Height { get; set; }
        public Cell[,] Cells { get; set; }
        public IInitializationMethod InitializationMethod
        {
            get => initializationMethod;
            set
            {
                initializationMethod = value;
                initializationMethod.Grid = this;
            }
        }

        public object Clone()
        {
            var grid = new Grid
            {
                Width = Width,
                Height = Height,
                Cells = new Cell[Width, Height]
            };

            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    grid.AddCell(Cells[x, y], x, y);
                }
            }

            return grid;
        }

        public void Init()
        {
            Cells = new Cell[Width, Height];
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    var cell = new Cell();
                    InitializationMethod.InitCell(cell, x, y);
                    AddCell(cell, x, y);
                }
            }
        }

        public void AddCell(Cell cell, int x, int y)
        {
            Cells[x, y] = cell;
        }
    }
}
