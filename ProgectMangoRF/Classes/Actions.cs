namespace ProjectMangoRF
{
    public class Actions
    {
        System.Random random = new System.Random();
        
        public void Heal(Player ActivePlayer, GamePage _GamePage)
        {
            if(GetRandom(75))
            {
                ActivePlayer.Health += ActivePlayer.Heal;
                _GamePage.Say("Success: " + ActivePlayer.Name + " heal themself.");
            }
            else
            {
                ActivePlayer.PoisonEffectTime += 5;
                _GamePage.Say("Failure: " + ActivePlayer.Name + " heal themself.");
            }
            ActivePlayer.Xp += 5;
        }

        public void Kick(Player ActivePlayer, Player PassivePlayer, GamePage _GamePage)
        {
            if (GetRandom(75))
            {
                int FullDamage = ActivePlayer.Damage + ActivePlayer.AdditionalDamage - PassivePlayer.Shield;
                if (FullDamage < 0)
                {
                    FullDamage = 0;
                }
                ActivePlayer.AdditionalDamage = 0;
                PassivePlayer.Shield = 0;
                PassivePlayer.Health -= FullDamage;

                _GamePage.Say("Success: " + ActivePlayer.Name + " kick " + PassivePlayer.Name);
            }
            else
            {
                ActivePlayer.Health -= ActivePlayer.Damage;
                _GamePage.Say("Failure: " + ActivePlayer.Name + " kick " + PassivePlayer.Name);
            }
            ActivePlayer.Xp += 5;
        }

        public void Spell(Player ActivePlayer, Player PassivePlayer, GamePage _GamePage)
        {
            //spells: grenade 0, shield 1, ultra heal 2, add additional damage 3, poison 4, additional xp 5

            if (GetRandom(75))
            {
                if (ActivePlayer.Spell == 0)
                {
                    PassivePlayer.Health -= ActivePlayer.Damage * 2;
                }
                else if (ActivePlayer.Spell == 1)
                {
                    ActivePlayer.Shield += PassivePlayer.Damage / 5;
                }
                else if (ActivePlayer.Spell == 2)
                {
                    ActivePlayer.Health += ActivePlayer.Heal * 2;
                }
                else if (ActivePlayer.Spell == 3)
                {
                    ActivePlayer.AdditionalDamage += ActivePlayer.Damage / 5;
                }
                else if (ActivePlayer.Spell == 4)
                {
                    PassivePlayer.PoisonEffectTime += 5;
                }
                else if (ActivePlayer.Spell == 5)
                {
                    ActivePlayer.Xp += 20;
                }

                _GamePage.Say("Success: " + ActivePlayer.Name + " use " + ActivePlayer.SpellName);
            }
            else
            {
                if (ActivePlayer.Spell == 0)
                {
                    ActivePlayer.Health -= ActivePlayer.Damage * 2;
                }
                else if (ActivePlayer.Spell == 2)
                {
                    ActivePlayer.PoisonEffectTime += 10;
                }
                else if (ActivePlayer.Spell == 4)
                {
                    ActivePlayer.PoisonEffectTime += 5;
                }
                _GamePage.Say("Failure: " + ActivePlayer.Name + " use " + ActivePlayer.SpellName);
            }
            ActivePlayer.Xp += 10;
        }

        bool GetRandom(int MinValue)
        {
            int Result = random.Next(MinValue, 100);
            if (Result >= MinValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
