using GameOfLife.Model.Initialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.View.Configuration
{
    public class InitializationFileChoiceEntry : ChoiceUserEntry<IInitializationMethod>
    {
        public InitializationFileChoiceEntry()
        {
            Question = "What initialization file do you whant to use ?";
            Help = "Choose a file pattern to set some cells alive on the first frame of the board.";
            AvailableEntries = new List<AvailableEntry<IInitializationMethod>>
            {
                new AvailableEntry<IInitializationMethod>
                {
                    Index = 1,
                    Label = "1 cell",
                    Value = new ModelFileInitialization("empty")
                },
                new AvailableEntry<IInitializationMethod>
                {
                    Index = 2,
                    Label = "Rabbit",
                    Value = new ModelFileInitialization("rabbit")
                },
                new AvailableEntry<IInitializationMethod>
                {
                    Index = 3,
                    Label = "Vertical line of 3 cells",
                    Value = new ModelFileInitialization("line3")
                },
                new AvailableEntry<IInitializationMethod>
                {
                    Index = 4,
                    Label = "Arrow to bottom right",
                    Value = new ModelFileInitialization("arrow")
                },
                new AvailableEntry<IInitializationMethod>
                {
                    Index = 5,
                    Label = "Starship v1",
                    Value = new ModelFileInitialization("starship1")
                }
            };
        }

        public IInitializationMethod DoRun()
        {
            IInitializationMethod value;
            do
            {
                value = Run();
            } while (value == null);

            return value;
        }

        public override void RunPartial()
        {
            userConfiguration.InitializationMethod = DoRun();
        }
    }
}
