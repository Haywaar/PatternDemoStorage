using UnityEngine;

public class DefaultDamageComponent : DamageComponent
{
    protected float _damage;

    public DefaultDamageComponent(float damage)
    {
        _damage = damage;
    }

    public override float GetDamage()
    {
        return _damage;
    }
}