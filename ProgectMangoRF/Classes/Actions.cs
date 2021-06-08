using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgectMangoRF
{
    public class Actions
    {
        public void Heal(Player ActivePlayer)
        {
            ActivePlayer.Health += ActivePlayer.Heal;
            ActivePlayer.Xp += 5;
        }

        public void Kick(Player ActivePlayer, Player PassivePlayer)
        {
            int FullDamage = ActivePlayer.Damage + ActivePlayer.AdditionalDamage - PassivePlayer.Shield;
            if (FullDamage < 0)
            {
                FullDamage = 0;
            }
            ActivePlayer.AdditionalDamage = 0;
            PassivePlayer.Shield = 0;
            PassivePlayer.Health -= FullDamage;
            ActivePlayer.Xp += 5;
        }

        public void Spell(Player ActivePlayer, Player PassivePlayer)
        {
            //spells: grenade 0, shield 1, ultra heal 2, add additional damage 3, poison 4, additional xp 5

            if(ActivePlayer.Spell == 0)
            {
                
            }
            else if (ActivePlayer.Spell == 1)
            {

            }
            else if (ActivePlayer.Spell == 2)
            {

            }
            else if (ActivePlayer.Spell == 3)
            {

            }
            else if (ActivePlayer.Spell == 4)
            {

            }
            else if (ActivePlayer.Spell == 5)
            {
                ActivePlayer.Xp += 20;
            }

            ActivePlayer.Xp += 10;
        }
    }
}
