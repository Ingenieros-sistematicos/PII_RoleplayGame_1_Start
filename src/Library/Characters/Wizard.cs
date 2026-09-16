using System;
using System.Collections.Generic;

public class Staff
{
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }

    public Staff(int attackValue, int defenseValue)
    {
        AttackValue = attackValue;
        DefenseValue = defenseValue;
    }
}

public class SpellBook
{
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }
    public List<Spell> Spells { get; set; }

    public SpellBook(int attackValue, int defenseValue)
    {
        AttackValue = attackValue;
        DefenseValue = defenseValue;
        Spells = new List<Spell>();
    }
}

public class Spell
{
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }

    public Spell(int attackValue, int defenseValue)
    {
        AttackValue = attackValue;
        DefenseValue = defenseValue;
    }
}

public class Wizard
{
    public string Name { get; set; }
    public Staff Staff { get; set; }
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