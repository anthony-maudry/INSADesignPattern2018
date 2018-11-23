using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.GameConfiguration;

namespace GameOfLife.View.Configuration
{
    public abstract class ConfigurationPartialViewBase : IConfigurationPartialView
    {
        protected UserConfiguration userConfiguration;

        public UserConfiguration UserConfiguration { set => userConfiguration = value; }

        public abstract void RunPartial();
    }
}
