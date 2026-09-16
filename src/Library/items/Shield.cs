namespace Library
{
    public class Shield:IItems
    {
        public int DefenseValue { get; set; }
        public int AttackValue {get; set; }

        public Shield(int defenseValue)
        {
            DefenseValue = defenseValue;
            AttackValue=0;
        }
    }
}