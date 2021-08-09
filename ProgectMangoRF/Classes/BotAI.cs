using System;

namespace ProjectMangoRF
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
                    _Actions.Kick(ActivePlayer, PassivePlayer, _GamePage);
                    break;

                case 1:
                    //heal
                    if(ActivePlayer.Spell == 2)
                    {
                        _Actions.Spell(ActivePlayer, PassivePlayer, _GamePage);
                        ActivePlayer.SetSpellName();
                    }
                    else
                    {
                        _Actions.Heal(ActivePlayer, _GamePage);
                    }
                    break;

                case 2:
                    //spell
                    _Actions.Spell(ActivePlayer, PassivePlayer, _GamePage);
                    ActivePlayer.SetSpellName();
                    break;
            }
        }

        public void TacticActions(Player ActivePlayer, Player PassivePlayer)
        {

        }
    }
}
