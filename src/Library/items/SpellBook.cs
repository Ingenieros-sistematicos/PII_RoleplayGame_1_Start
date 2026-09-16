using System.Collections.Generic;
namespace Library{
public class SpellBook:IItems
{
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }
    public List<Spell> Spells { get; set; }

    public SpellBook(int attackValue, int defenseValue, List<Spell> SpellList)
    {
        AttackValue = attackValue;
        DefenseValue = defenseValue;
        Spells = SpellList;
    }
    public void AddSpell(Spell spell)
        {
            this.Spells.Add(spell);
        }
}}