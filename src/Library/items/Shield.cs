namespace Library
{
    public class Shield:IDefense
    {
        public int DefenseValue { get; set; }

        public Shield(int defenseValue)
        {
            DefenseValue = defenseValue;
        }
    }
}