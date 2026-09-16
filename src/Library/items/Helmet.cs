namespace Library
{
public class Helmet:IItems
{
    public int DefenseValue { get; set; }
    public int AttackValue {get; set; }

    public Helmet(int defenseValue)
    {
        DefenseValue = defenseValue;
        AttackValue=0;
    }
}}