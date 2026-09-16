namespace Library
{ 
    public class Staff:IItems
    {
        public int AttackValue { get; set; }
        public int DefenseValue { get; set; }

        public Staff(int attackValue, int defenseValue)
        {
            AttackValue = attackValue;
            DefenseValue = defenseValue;
        }
    }
}
