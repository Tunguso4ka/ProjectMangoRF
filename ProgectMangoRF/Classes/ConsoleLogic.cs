using System;
using System.Windows.Controls;

namespace ProjectMangoRF
{
    class ConsoleLogic
    {
        string[] CommandMassive;
        public void Command(string CommandText, GamePage gamePage)
        {
            CommandMassive = CommandText.Split(' ');
            if (CommandMassive[0].Equals("Help", StringComparison.OrdinalIgnoreCase))
            {
                if(CommandMassive.Length > 1)
                {

                }
                else
                {
                    gamePage.MainConsoleTextBox.Text += gamePage.Minutes + ":" + gamePage.Seconds + " - Help: Help | Window | Game | Player0/1 | \n";
                }
            }
            else if (CommandMassive[0].Equals("Window", StringComparison.OrdinalIgnoreCase))
            {
                if (CommandMassive.Length > 1)
                {

                }
                else
                {

                }
            }
            else if (CommandMassive[0].Equals("Game", StringComparison.OrdinalIgnoreCase))
            {
                if (CommandMassive.Length > 1)
                {

                }
                else
                {

                }
            }
            else if (CommandMassive[0].Equals("Player0", StringComparison.OrdinalIgnoreCase))
            {
                if (CommandMassive.Length > 1)
                {

                }
                else
                {

                }
            }
            else if (CommandMassive[0].Equals("Player1", StringComparison.OrdinalIgnoreCase))
            {
                if (CommandMassive.Length > 1)
                {

                }
                else
                {

                }
            }
        }
    }
}
