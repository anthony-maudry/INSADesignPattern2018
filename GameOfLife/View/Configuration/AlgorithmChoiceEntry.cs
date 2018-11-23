using GameOfLife.Model.LifeAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.View.Configuration
{
    public class AlgorithmChoiceEntry : ChoiceUserEntry<ILifeAlgorithm>
    {

        public AlgorithmChoiceEntry()
        {
            QuestionTitle = "What algorithm to you whant to use ?";
            Help = "The algorithm will be applyed on each frame of the game," + Environment.NewLine +
                "until the board is stable or you decide to stop it.";
            AvailableEntries = new List<AvailableEntry<ILifeAlgorithm>>
            {
                new AvailableEntry<ILifeAlgorithm>
                {
                    Index = 1,
                    Label = "Exercise first algo",
                    Value = new FirstLifeAlgorithm()
                },
                new AvailableEntry<ILifeAlgorithm>
                {
                    Index = 2,
                    Label = "Exercise second algo",
                    Value = new SecondLifeAlgorithm()
                },
                new AvailableEntry<ILifeAlgorithm>
                {
                    Index = 3,
                    Label = "Conway algo",
                    Value = new ConwayAlgorithm()
                }
            };
        }

        public override void RunPartial()
        {
            ILifeAlgorithm algorithm;

            do
            {
                algorithm = Run();
            } while (algorithm == null);

            userConfiguration.LifeAlgorithm = algorithm;
        }
    }
}
