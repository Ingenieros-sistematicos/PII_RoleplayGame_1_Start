namespace Library
{
    public class Armor:IItems
    {
        public int DefenseValue { get; set; }
        public int AttackValue {get; set; }

        public Armor(int defenseValue)
        {
            DefenseValue = defenseValue;
            AttackValue = 0;
        }
    }
}