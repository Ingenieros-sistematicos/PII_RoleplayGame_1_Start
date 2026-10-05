using System.Collections.Generic;

namespace Library.Characters
{
    public abstract class Character
    {
        public string Name { get; set; } = string.Empty;
        public int Health { get; set; }
        public int Vp { get; set; }
        public List<IItems> Items{get; set;}
        public Character(string name)
        {
            Name = name;
            Health = 100;
            Items= new List<IItems>{};
        }
        public void ReceiveAttack(int power)
        {
            int defenseTotal =0;
            for (int i = 0; i < this.Items.Count; i++)
            {
                if(this.Items[i].DefenseValue!=null)
                {
                    defenseTotal+=this.Items[i].DefenseValue;
                }
            }
            int damage = power - defenseTotal;

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
            Health += 10;
            if (Health > 100)
            {
                Health = 100;
            }
        }
        List<Hero> Heroes = new List<Hero>();
        List<BadBoys> BadBoys = new List<BadBoys>();
        public void AddEncounterHero(Hero hero)
        {
            Heroes.Add(hero);
        }
        public void AddEncounterBadBoy(BadBoys BadBoy)
        {
            BadBoys.Add(BadBoy);
        }
        public void DoEncounter(List<Hero> Heroes, List<BadBoys> BadBoys)
        {
            while (Heroes.Count!=0 | BadBoys.Count !=0)
            {
                for (int i = 0; i < BadBoys.Count; i++)
                {
                    if (Heroes[i%Heroes.Count].Health <= 0)
                    {
                        Heroes.Remove(Heroes[i % Heroes.Count]);
                    }
                    else
                    {
                        for (int j = 0; j < BadBoys[i].Items.Count; j++)
                        {
                            Heroes[i%Heroes.Count].ReceiveAttack(BadBoys[i].Items[j].AttackValue);
                        }
                    }
                }
                for (int i = 0; i < Heroes.Count; i++)
                {
                    for ( int k = 0; k < BadBoys.Count; k++)
                    {
                        if (BadBoys[k].Health <= 0)
                        {
                            BadBoys.Remove(BadBoys[k]);
                            Heroes[i].AddVP(BadBoys[k].Vp);
                        }
                        else
                        {
                            for (int j = 0; j < Heroes[i].Items.Count; j++)
                            {
                                BadBoys[k].ReceiveAttack(Heroes[i].Items[j].AttackValue);
                            }
                        }
                    }
                }
            }
        }
    }
}