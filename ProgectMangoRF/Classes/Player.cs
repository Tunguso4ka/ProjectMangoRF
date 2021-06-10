namespace ProgectMangoRF
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
        public int Shield { get; set; }

        //Damage system
        public int Damage;
        public int AdditionalDamage { get; set; }

        //Magic system
        public int Spell { get; set; }
        public int PoisonEffectTime { get; set; }

        public void LevelUp()
        {
            Xp -= 100;
            Lvl += 1;

            Heal += 5;
            MaxHealth += 50;

            Damage += 5;

            PoisonEffectTime = 0;
        }
    }
}
