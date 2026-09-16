using System.Collections.Generic;

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