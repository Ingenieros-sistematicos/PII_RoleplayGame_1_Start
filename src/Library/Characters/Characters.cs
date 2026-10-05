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
            // Los personajes que ya estaban derrotados no participan.
            Heroes.RemoveAll(hero => hero.Health <= 0);
            BadBoys.RemoveAll(enemy => enemy.Health <= 0);

            while (Heroes.Count > 0 && BadBoys.Count > 0)
            {
                bool damageDealt = false;

                // Los enemigos atacan primero, distribuyéndose entre los héroes.
                for (int i = 0; i < BadBoys.Count && Heroes.Count > 0; i++)
                {
                    Hero target = Heroes[i % Heroes.Count];
                    int previousHealth = target.Health;
                    for (int j = 0; j < BadBoys[i].Items.Count && target.Health > 0; j++)
                    {
                        target.ReceiveAttack(BadBoys[i].Items[j].AttackValue);
                    }

                    damageDealt |= target.Health < previousHealth;
                    if (target.Health <= 0)
                    {
                        Heroes.Remove(target);
                    }
                }

                for (int i = 0; i < Heroes.Count && BadBoys.Count > 0; i++)
                {
                    int k = 0;
                    while (k < BadBoys.Count)
                    {
                        BadBoys enemy = BadBoys[k];
                        int previousHealth = enemy.Health;
                        for (int j = 0; j < Heroes[i].Items.Count && enemy.Health > 0; j++)
                        {
                            enemy.ReceiveAttack(Heroes[i].Items[j].AttackValue);
                        }

                        damageDealt |= enemy.Health < previousHealth;
                        if (enemy.Health <= 0)
                        {
                            // Conservar la referencia permite otorgar los VP del enemigo correcto.
                            Heroes[i].AddVP(enemy.Vp);
                            BadBoys.RemoveAt(k);
                            // El siguiente enemigo ocupa el mismo índice.
                        }
                        else
                        {
                            k++;
                        }
                    }
                }

                // Sin daño en una ronda, el combate no puede avanzar.
                if (!damageDealt)
                {
                    break;
                }
            }
        }
    }
}
