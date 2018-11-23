using GameOfLife.GameConfiguration;
using GameOfLife.View.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.View
{
    public class ConfigurationView
    {
        protected readonly UserConfiguration userConfiguration;

        private readonly IConfigurationPartialView[] configurationPartialViews = 
        {
            new GridWidthPartialView(),
            new GridHeightPartialView(),
            new FrameRateEntry(),
            new InitializationChoiceEntry(),
            new AlgorithmChoiceEntry()
        };

        public ConfigurationView(UserConfiguration userConfiguration)
        {
            this.userConfiguration = userConfiguration;
        }

        public void Run()
        {
            foreach(var partialView in configurationPartialViews)
            {
                partialView.UserConfiguration = userConfiguration;
                partialView.RunPartial();
            }
        }
    }
}
