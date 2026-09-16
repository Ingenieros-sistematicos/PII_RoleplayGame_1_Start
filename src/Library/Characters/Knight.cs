namespace Library
{
    public class Knight
    {
        public string Name { get; set; }

        public IItems Sword { get; set; }
        public IItems Shield { get; set; }
        public IItems Armor { get; set; }
    
        public int AttackValue
        {
            get
            {
                int attack=0;
                if (Sword != null)
                {
                    attack += Sword.AttackValue ;

                }
                return attack;


            }
        }
        public int DefenseValue
        {
            get
            {
                int defense = 0;

                if (Shield != null)
                {
                    defense += Shield.DefenseValue;
                }

                if (Armor != null)
                {
                    defense += Armor.DefenseValue;
                }

                return defense;
            }
        }
         public int Health { get; set; }
          public Knight(string name)
        {
            Name = name;
            Health = 100;
        }
          public void ReceiveAttack(int power)
        {
            int damage = power - DefenseValue;

            if (damage > 0)
            {
                Health -= damage;
            }

            if (Health < 0)
            {
                Health = 0;
            }
        }

        public void Cure()
        {
            Health = 100;
        }
    }
}