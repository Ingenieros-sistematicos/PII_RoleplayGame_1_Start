namespace Library
{
public class Bow:IAttack
{
    public int AttackValue {get; set; }

    public Bow(int attackValue)
    {
        AttackValue = attackValue;
    }
}}