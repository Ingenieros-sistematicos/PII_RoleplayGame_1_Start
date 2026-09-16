namespace Library
{
    public class Armor:IDefense
    {
        public int DefenseValue { get; set; }

        public Armor(int defenseValue)
        {
            DefenseValue = defenseValue;
        }
    }
}