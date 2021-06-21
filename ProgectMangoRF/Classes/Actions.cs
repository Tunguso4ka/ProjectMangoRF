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

            ActivePlayer.Xp += 10;
        }
    }
}
