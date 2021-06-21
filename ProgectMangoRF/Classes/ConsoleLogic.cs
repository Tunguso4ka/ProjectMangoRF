using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgectMangoRF
{
    class ConsoleLogic
    {
        string[] CommandMassive;
        public void Command(string CommandText)
        {
            CommandMassive = CommandText.Split(' ');
            if (CommandMassive[0].Equals("Help", StringComparison.OrdinalIgnoreCase))
            {

            }
            else if (CommandMassive[0].Equals("Window", StringComparison.OrdinalIgnoreCase))
            {

            }
            else if (CommandMassive[0].Equals("Game", StringComparison.OrdinalIgnoreCase))
            {

            }
            else if (CommandMassive[0].Equals("Player0", StringComparison.OrdinalIgnoreCase))
            {

            }
            else if (CommandMassive[0].Equals("Player1", StringComparison.OrdinalIgnoreCase))
            {

            }
        }
    }
}
