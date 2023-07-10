public class Mage : Unit
{
    public override int GetPrice()
    {
        if (IsThird())
        {
            return 40;
        }
        else
        {
            return 20;
        }
    }

    public void CastSpell()
    {
    }
}