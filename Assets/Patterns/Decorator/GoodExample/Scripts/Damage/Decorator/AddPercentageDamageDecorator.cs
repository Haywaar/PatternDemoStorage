using UnityEngine;

public class AddPercentageDamageDecorator : DamageDecorator
{
    private readonly float _percentage;

    public AddPercentageDamageDecorator(DamageComponent component, float percentage) : base(component)
    {
        _percentage = percentage;
    }

    public override float GetDamage()
    {
        return _component.GetDamage() * (1 + _percentage);
    }
}