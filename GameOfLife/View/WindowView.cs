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
        private enum StopReason { None, Stable, OverCrowded, Sterilized, User }
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
            var reason = StopReason.None;

            configuration.LifeAlgorithm.OnStabilized += (s, e) => { stop = true; reason = StopReason.Stable; };
            configuration.LifeAlgorithm.OnOverCrowded += (s, e) => { stop = true; reason = StopReason.OverCrowded; };
            configuration.LifeAlgorithm.OnSterilized += (s, e) => { stop = true; reason = StopReason.Sterilized; };
            UserEntryStop += (s, e) => { stop = true; reason = StopReason.User; };

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
                    switch(reason)
                    {
                        case StopReason.User:
                            Console.WriteLine("You stoped the game !");
                            break;
                        case StopReason.Sterilized:
                            Console.WriteLine("No one survived, too bad :'(");
                            break;
                        case StopReason.Stable:
                            Console.WriteLine("And the world ends, smoothly, stabilized");
                            break;
                        case StopReason.OverCrowded:
                            Console.WriteLine("We are all alive !");
                            break;
                        default:
                            Console.WriteLine("Ok the world ended, but we do not know why. But who cares ?");
                            break;
                    }
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
