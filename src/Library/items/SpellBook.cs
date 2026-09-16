using System.Collections.Generic;
namespace Library{
public class SpellBook:IItems
{
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }
    public List<Spell> Spells { get; set; }
    

    public SpellBook(int attackValue, int defenseValue, List<Spell> SpellList)
    {
        Spells = SpellList;
        int defenseTotal =0;
            for (int i = 0; i < this.Spells.Count; i++)
            {
                defenseTotal+=this.Spells[i].DefenseValue;
            }
        int attackTotal =0;
            for (int i = 0; i < this.Spells.Count; i++)
            {
                attackTotal+=this.Spells[i].DefenseValue;
            }
        AttackValue = attackValue+attackTotal;
        DefenseValue = defenseValue+defenseTotal;
    }
    public void AddSpell(Spell spell)
        {
            this.Spells.Add(spell);
        }
}}