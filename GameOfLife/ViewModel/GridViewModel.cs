using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Model;
using SFML.Graphics;

namespace GameOfLife.ViewModel
{
    public class GridViewModel : IDrawable
    {
        private const int QUAD_SIZE = 4;
        private const int CELL_SIZE = 5;
        private readonly Grid grid;

        public Drawable DrawableObject { get; protected set; }

        public GridViewModel(Grid grid)
        {
            this.grid = grid;
            MakeDrawable();
        }

        private void MakeDrawable()
        {
            var vertexArray = new VertexArray(PrimitiveType.Quads, QUAD_SIZE * (uint)grid.Width * (uint)grid.Height);

            for (var x = 0; x < grid.Width; x++)
            {
                for (var y = 0; y < grid.Height; y++)
                {
                    for (uint i = 0; i < QUAD_SIZE; i++)
                    {

                        var cell = grid.Cells[x, y];
                        var vertex = vertexArray[((uint)x + (uint)y * (uint)grid.Height) * 4 + i];

                        uint xIndex = (uint)x;
                        uint yIndex = (uint)y;

                        switch (i)
                        {
                            case 1:
                                xIndex++;
                                break;
                            case 2:
                                xIndex++;
                                yIndex++;
                                break;
                            case 3:
                                yIndex++;
                                break;
                        }
                        vertex.Position = new SFML.System.Vector2f(xIndex * CELL_SIZE, yIndex * CELL_SIZE);
                        vertex.Color = cell.IsAlive ? Color.White : Color.Black;
                        vertexArray[((uint)x + (uint)y * (uint)grid.Height) * 4 + i] = vertex;
                    }
                }
            }

            DrawableObject = vertexArray;
        }
    }
}
