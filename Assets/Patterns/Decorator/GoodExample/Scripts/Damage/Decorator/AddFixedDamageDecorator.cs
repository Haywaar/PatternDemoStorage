using UnityEngine;

public class AddFixedDamageDecorator : DamageDecorator
{
    protected float _addDamage;
    public AddFixedDamageDecorator(DamageComponent component, float addDamage) : base(component)
    {
        _addDamage = addDamage;
    }

    public override float GetDamage()
    {
        return _addDamage + _component.GetDamage();
    }
}