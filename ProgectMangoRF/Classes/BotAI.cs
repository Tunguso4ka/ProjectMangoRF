using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgectMangoRF
{
    class BotAI
    {
        Actions _Actions = new Actions();
        public void DoAction( Player ActivePlayer, Player PassivePlayer, bool FullRandom, GamePage _GamePage)
        {
            if(FullRandom == true)
            {
                FullRandomActions(ActivePlayer, PassivePlayer, _GamePage);
            }
            else
            {

            }
        }

        public void FullRandomActions(Player ActivePlayer, Player PassivePlayer, GamePage _GamePage)
        {
            Random _Random = new Random();
            int i = _Random.Next(0,3);
            switch(i)
            {
                case 0:
                    //hit
                    _Actions.Kick(ActivePlayer, PassivePlayer);
                    _GamePage.Say(ActivePlayer.Name + " kick " + PassivePlayer.Name);
                    break;

                case 1:
                    //heal
                    if(ActivePlayer.Spell == 2)
                    {
                        _Actions.Spell(ActivePlayer, PassivePlayer);
                        ActivePlayer.SetSpellName();
                        _GamePage.Say(ActivePlayer.Name + " use " + ActivePlayer.SpellName);
                    }
                    else
                    {
                        _Actions.Heal(ActivePlayer);
                        _GamePage.Say(ActivePlayer.Name + " heal themself.");
                    }
                    break;

                case 2:
                    //spell
                    _Actions.Spell(ActivePlayer, PassivePlayer);
                    ActivePlayer.SetSpellName();
                    _GamePage.Say(ActivePlayer.Name + " use " + ActivePlayer.SpellName);
                    break;
            }
        }

        public void TacticActions(Player ActivePlayer, Player PassivePlayer)
        {

        }
    }
}
