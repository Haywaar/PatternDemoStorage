public abstract class DamageDecorator : DamageComponent
{
    protected DamageComponent _component;

    public DamageDecorator(DamageComponent component)
    {
        _component = component;
    }


    public override float GetDamage()
    {
        return _component.GetDamage();
    }
}