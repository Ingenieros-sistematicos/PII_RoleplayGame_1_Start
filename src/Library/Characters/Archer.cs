using System.Collections.Generic;

namespace Library
{
public class Archer
{
    public string Name { get; }
    public IItems Bow { get; }
    public IItems Helmet { get; }
    public int AttackValue { get; }
    public int DefenseValue { get; }
    public int Health { get; private set; }
    public List<IItems> Items{get; set;}

    public Archer(string name)
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
}}