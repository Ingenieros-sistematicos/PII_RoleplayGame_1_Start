using System;
using System.Collections.Generic;
using Library;


public class Dwarf
{
    public string Name { get; set; }
    public IItems Axe { get; set; }
    public IItems Shield { get; set; }
    public IItems Helmet { get; set; }
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }
    public int Health { get; set; }
    
    public List<IItems> Items{get; set;}

    public Dwarf(string name)
    {
        Name = name;
        Health = 100;
    }
    public void AddItem(IItems item)
    {
        Items.Add(item);
    }

    public void ReceiveAttack(int power)
    {
        int defenseTotal =DefenseValue;
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

    public void Cure()
    {
        Health += 10;
        if (Health > 100)
        {
            Health = 100;
        }
    }
}