
public class UnlimitedSpinsModel : Model
{
    public UnlimitedSpinsModel(View view) : base(view)
    {
    }
    public override bool HaveSpins()
    {
        return true;
    }
}
