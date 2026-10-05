namespace Library.Characters
{
    public abstract class Hero : Character
    {
        public Hero(string name) : base(name)
        {
            Vp=1;
        }

        public void AddVP(int AddedVP)
        {
            if(AddedVP>=5)
            {
                this.Vp+=AddedVP;
            }
        }
        public void AddItem(IItems item)
        {
            Items.Add(item);
        }
    }
}