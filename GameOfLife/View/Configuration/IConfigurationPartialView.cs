using GameOfLife.GameConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.View.Configuration
{
    public interface IConfigurationPartialView
    {
        UserConfiguration UserConfiguration { set; }

        void RunPartial();
    }
}
