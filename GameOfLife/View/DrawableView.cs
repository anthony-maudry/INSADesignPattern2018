using GameOfLife.ViewModel;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.View
{
    class DrawableView : Drawable
    {
        private readonly IDrawable drawable;

        public DrawableView(IDrawable drawable)
        {
            this.drawable = drawable;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(drawable.DrawableObject, states);
        }
    }
}
