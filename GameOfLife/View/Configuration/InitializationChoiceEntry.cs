using GameOfLife.Model.Initialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.View.Configuration
{
    public class InitializationChoiceEntry : ChoiceUserEntry<IInitializationMethod>
    {
        public InitializationChoiceEntry()
        {
            QuestionTitle = "How do you want to initialize the board ?";
            Help = "Choose a pattern to set some cells aline on the first frame of the board.";
            AvailableEntries = new List<AvailableEntry<IInitializationMethod>>
            {
                new AvailableEntry<IInitializationMethod>
                {
                    Index = 1,
                    Label = "Random",
                    Value = new RandomInitializationMethod()
                },
                new AvailableEntry<IInitializationMethod>
                {
                    Index = 2,
                    Label = "Chessboard",
                    Value = new ChessBoardInitializationMethod()
                },
                new AvailableEntry<IInitializationMethod>
                {
                    Index = 3,
                    Label = "File",
                    Value = new ModelFileInitialization("empty")
                }
            };
        }

        public override void RunPartial()
        {
            IInitializationMethod value;
            do
            {
                value = Run();
            } while (value == null);

            if(value is ModelFileInitialization)
            {
                value = new InitializationFileChoiceEntry().DoRun();
            }

            userConfiguration.InitializationMethod = value;
        }
    }
}
