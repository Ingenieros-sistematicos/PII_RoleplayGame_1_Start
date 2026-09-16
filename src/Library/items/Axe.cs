namespace Library
{
public class Axe:IAttack
{
    public int AttackValue {get; set; }

    public Axe(int attackValue)
    {
        AttackValue = attackValue;
    }
}}
