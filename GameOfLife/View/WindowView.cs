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
        public event EventHandler UserEntryStop;

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
            app.KeyPressed += Window_KeyPressed;

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

            bool stop = false;

            configuration.LifeAlgorithm.OnStabilized += (s, e) => { stop = true; };
            configuration.LifeAlgorithm.OnOverCrowded += (s, e) => { stop = true; };
            configuration.LifeAlgorithm.OnSterilized += (s, e) => { stop = true; };
            UserEntryStop += (s, e) => { stop = true; };

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

                if (stop)
                {
                    app.Close();
                }
            } //End game loop
        }

        private void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.Return:
                    UserEntryStop?.Invoke(sender, new EventArgs());
                    break;
            }
        }
    }
}
