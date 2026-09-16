namespace Library
{
public class Helmet:IDefense
{
    public int DefenseValue { get; set; }

    public Helmet(int defenseValue)
    {
        DefenseValue = defenseValue;
    }
}}