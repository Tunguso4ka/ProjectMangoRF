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
                    gamePage.MainConsoleTextBox.Text = gamePage.Minutes + ":" + gamePage.Seconds + " - Help: Help | Window | Game | Player0/1 Name/Lvl/MaxXp/Xp/MaxHealth/Health/Heal/Shield/Damage/AdditionalDamage/Spell/PoisonEffectTime | \n" + gamePage.MainConsoleTextBox.Text;
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
                    if (CommandMassive[1].Equals("Name", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player0.Name = CommandMassive[2];

                    else if (CommandMassive[1].Equals("Lvl", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player0.Lvl = Convert.ToInt32(CommandMassive[2]);

                    else if (CommandMassive[1].Equals("MaxXp", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player0.MaxXp = Convert.ToInt32(CommandMassive[2]);

                    else if (CommandMassive[1].Equals("Xp", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player0.Xp = Convert.ToInt32(CommandMassive[2]);

                    else if (CommandMassive[1].Equals("MaxHealth", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player0.MaxHealth = Convert.ToInt32(CommandMassive[2]);

                    else if (CommandMassive[1].Equals("Health", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player0.Health = Convert.ToInt32(CommandMassive[2]);

                    else if (CommandMassive[1].Equals("Heal", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player0.Heal = Convert.ToInt32(CommandMassive[2]);

                    else if (CommandMassive[1].Equals("Shield", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player0.Shield = Convert.ToInt32(CommandMassive[2]);

                    else if (CommandMassive[1].Equals("Damage", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player0.Damage = Convert.ToInt32(CommandMassive[2]);

                    else if (CommandMassive[1].Equals("AdditionalDamage", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player0.AdditionalDamage = Convert.ToInt32(CommandMassive[2]);

                    else if (CommandMassive[1].Equals("Spell", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player0.Spell = Convert.ToInt32(CommandMassive[2]);

                    else if (CommandMassive[1].Equals("PoisonEffectTime", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player0.PoisonEffectTime = Convert.ToInt32(CommandMassive[2]);
                }
                else
                {

                }
            }
            else if (CommandMassive[0].Equals("Player1", StringComparison.OrdinalIgnoreCase))
            {
                if (CommandMassive.Length > 1)
                {
                    if (CommandMassive[1].Equals("Name", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player1.Name = CommandMassive[2];

                    else if (CommandMassive[1].Equals("Lvl", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player1.Lvl = Convert.ToInt32(CommandMassive[2]);

                    else if (CommandMassive[1].Equals("MaxXp", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player1.MaxXp = Convert.ToInt32(CommandMassive[2]);

                    else if (CommandMassive[1].Equals("Xp", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player1.Xp = Convert.ToInt32(CommandMassive[2]);

                    else if (CommandMassive[1].Equals("MaxHealth", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player1.MaxHealth = Convert.ToInt32(CommandMassive[2]);

                    else if (CommandMassive[1].Equals("Health", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player1.Health = Convert.ToInt32(CommandMassive[2]);

                    else if (CommandMassive[1].Equals("Heal", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player1.Heal = Convert.ToInt32(CommandMassive[2]);

                    else if (CommandMassive[1].Equals("Shield", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player1.Shield = Convert.ToInt32(CommandMassive[2]);

                    else if (CommandMassive[1].Equals("Damage", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player1.Damage = Convert.ToInt32(CommandMassive[2]);

                    else if (CommandMassive[1].Equals("AdditionalDamage", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player1.AdditionalDamage = Convert.ToInt32(CommandMassive[2]);

                    else if (CommandMassive[1].Equals("Spell", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player1.Spell = Convert.ToInt32(CommandMassive[2]);

                    else if (CommandMassive[1].Equals("PoisonEffectTime", StringComparison.OrdinalIgnoreCase))
                        gamePage.Player1.PoisonEffectTime = Convert.ToInt32(CommandMassive[2]);
                }
                else
                {

                }
            }
        }
    }
}
