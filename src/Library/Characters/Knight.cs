using System.Collections.Generic;

namespace Library
{
    public class Knight
    {
        public string Name { get; set; }
        
        public List<IItems> Items{get; set;}
        public void ReceiveAttack(int power)
        {
            int defenseTotal =0;
            for (int i = 0; i < this.Items.Count; i++)
            {
                if(this.Items[i].DefenseValue!=null)
                {
                    defenseTotal+=this.Items[i].DefenseValue;
                }
            }
            int damage = power - defenseTotal;

            if (damage > 0)
            {
                Health -= damage;
            }

            if (Health < 0)
            {
                Health = 0;
            }
        }
        public void AddItem(IItems item)
        {
            Items.Add(item);
        }
         public int Health { get; set; }
          public Knight(string name)
        {
            Name = name;
            Health = 100;
            Items= new List<IItems>{};
        }

        public void Cure()
        {
            Health = 100;
        }
    }
}