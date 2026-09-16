namespace Library
{
public class Axe:IItems
{
    public int DefenseValue { get; set; }
    public int AttackValue {get; set; }

    public Axe(int attackValue)
    {
        AttackValue = attackValue;
        DefenseValue =0;
    }
}}
