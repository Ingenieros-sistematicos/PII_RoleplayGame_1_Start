using System;
using System.Collections.Generic;

namespace Library
{
    public class Wizard
    {
        public string Name { get; set; }
        public IItems Staff { get; set; }
        public SpellBook Spellbook { get; set; }
        public int AttackValue { get; set; }
        public int DefenseValue { get; set; }
        public int Health { get; set; }

        public Wizard(string name)
        {
            Name = name;
            Health = 100;
        }

        public void ReceiveAttack(int power)
        {
            int defenseTotal = DefenseValue + (Staff?.DefenseValue ?? 0) + (Spellbook?.DefenseValue ?? 0);
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