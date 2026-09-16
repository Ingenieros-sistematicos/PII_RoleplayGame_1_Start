namespace Library
{
    public class Sword:IItems
    {
        public int DefenseValue { get; set; }
        public int AttackValue {get; set; }

        public Sword(int attackValue)
        {
            AttackValue = attackValue;
            DefenseValue=0;
        }
    }
}