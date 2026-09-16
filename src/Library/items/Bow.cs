namespace Library
{
public class Bow:IItems
{
    public int DefenseValue { get; set; }
    public int AttackValue {get; set; }

    public Bow(int attackValue)
    {
        AttackValue = attackValue;
        DefenseValue=0;
    }
}}