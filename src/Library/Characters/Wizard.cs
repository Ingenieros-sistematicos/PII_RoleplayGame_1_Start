using System;
using System.Collections.Generic;

namespace Library
{
    public class Wizard
    {
        public string Name { get; set; }
        public SpellBook Spellbook { get; set; }
        public int AttackValue { get; set; }
        public int DefenseValue { get; set; }
        public int Health { get; set; }
        
        public List<IItems> Items{get; set;}

        public Wizard(string name)
        {
            Name = name;
            Health = 100;
            Items= new List<IItems>{};
        }
        public void AddItem(IItems item)
        {
            Items.Add(item);
        }

        public void ReceiveAttack(int power)
        {
            int defenseTotal = Spellbook.DefenseValue;
            for (int i = 0; i < this.Items.Count; i++)
            {
                if(this.Items[i].DefenseValue!=0)
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
    }
}