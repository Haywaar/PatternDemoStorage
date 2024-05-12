using UnityEngine;

public class DamageComponent
{
   public readonly DamageComponentType DamageComponentType;
   public readonly float Value;

    public DamageComponent(DamageComponentType damageComponentType, float value)
    {
        DamageComponentType = damageComponentType;
        Value = value;
    }
}