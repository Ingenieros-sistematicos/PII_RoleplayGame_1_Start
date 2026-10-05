namespace Library.Characters
{
    public class BadBoys : Character
    {
        public BadBoys(string name) : base(name)
        {
        }

        public void SetVP(int vp)
        {
            Vp = vp;
        }
    }
}