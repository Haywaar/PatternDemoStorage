public class Ranger : Unit
{
    public override int GetPrice()
    {
        if (IsThird())
        {
            return 10;
        }

        return 30;
    }
}