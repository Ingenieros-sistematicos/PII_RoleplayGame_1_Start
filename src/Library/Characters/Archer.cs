namespace Library
{
public class Archer
{
    private const int DefaultAttackValue = 15;
    private const int DefaultDefenseValue = 8;
    private const int MaxHealth = 100;

    public string Name { get; }
    public IItems Bow { get; }
    public IItems Helmet { get; }
    public int AttackValue { get; }
    public int DefenseValue { get; }
    public int Health { get; private set; }

    public Archer(string name)
    {
        Name = name;
        Bow = new Bow(DefaultAttackValue);
        Helmet = new Helmet(DefaultDefenseValue);
        AttackValue = Bow.AttackValue;
        DefenseValue = Helmet.DefenseValue;
        Health = MaxHealth;
    }

    public void ReceiveAttack(int power)
    {
        int damage = power - DefenseValue;

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