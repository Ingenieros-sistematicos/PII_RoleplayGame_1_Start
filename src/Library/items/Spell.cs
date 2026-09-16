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