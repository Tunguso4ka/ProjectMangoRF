using Locale = ProjectMangoRF.Properties.Locale;

namespace ProjectMangoRF
{
    public class Player
    {
        //Main information
        public string Name { get; set; }

        //Level system
        public int Lvl { get; set; }
        public int MaxXp { get; set; }
        public int Xp { get; set; }

        //Health system
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int Heal { get; set; }
        public int Chance { get; set; }
        public int Shield { get; set; }

        //Damage system
        public int Damage { get; set; }
        public int AdditionalDamage { get; set; }

        //Magic system
        public string SpellName { get; set; }
        public int Spell { get; set; }
        public int PoisonEffectTime { get; set; }

        public void LevelUp()
        {
            if (Xp >= 100)
            {
                Xp -= 100;
                Lvl += 1;

                Heal += 5;
                MaxHealth += 50;

                Damage += 5;

                PoisonEffectTime = 0;

                Chance = 10;
            }
        }

        public void HealthRegulator()
        {
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            else if (Health < 0)
            {
                Health = 0;
            }
        }

        public void ChanceRegulator()
        {
            if (Chance > 10)
            {
                Chance = 10;
            }
            else if (Chance < 0)
            {
                Chance = 0;
            }
        }

        public void SetSpellName()
        {
            switch (Spell)
            {
                case 0:
                    SpellName = Locale.Locale.Bomb;
                    break;
                case 1:
                    SpellName = Locale.Locale.Shield;
                    break;
                case 2:
                    SpellName = Locale.Locale.DoubleHeal;
                    break;
                case 3:
                    SpellName = Locale.Locale.AdditionalDamagePotion;
                    break;
                case 4:
                    SpellName = Locale.Locale.PoisonPotion;
                    break;
                case 5:
                    SpellName = Locale.Locale.XPPotion;
                    break;
            }
}
    }
}
