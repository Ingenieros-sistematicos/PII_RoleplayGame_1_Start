namespace Library
{
    public class Sword:IAttack
    {
        public int AttackValue {get; set; }

        public Sword(int attackValue)
        {
            AttackValue = attackValue;
        }
    }
}