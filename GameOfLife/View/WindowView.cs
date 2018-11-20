using GameOfLife.GameConfiguration;
using GameOfLife.Model;
using GameOfLife.ViewModel;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.View
{
    public class WindowView
    {
        private readonly IGameConfiguration configuration;

        static void OnClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        public WindowView(IGameConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Run()
        {
            // Create the main window
            RenderWindow app = new RenderWindow(new VideoMode(1000, 1000), "SFML Works!");
            app.Closed += new EventHandler(OnClose);

            Color windowColor = Color.Green;

            var c = new Clock();

            // Create the grid
            var grid = new Grid
            {
                Height = configuration.GridHeight,
                Width = configuration.GridWidth,
                InitializationMethod = configuration.InitializationMethod
            };

            grid.Init();

            // Start the game loop
            while (app.IsOpen)
            {
                // Process events
                app.DispatchEvents();

                if ((c.ElapsedTime.AsMilliseconds() % configuration.MillisecondsBetweenFrames) == 0)
                {
                    grid = configuration.LifeAlgorithm.Apply(grid);

                    var view = new DrawableView(new GridViewModel(grid));

                    // Clear screen
                    app.Clear(windowColor);

                    app.Draw(view);

                    // Update the window
                    app.Display();
                }
            } //End game loop
        }

        private void Window_KeyPressed(object sender, KeyEventArgs e)
        {

        }
    }
}
