using Patterns.DIExample.Scripts;
using UnityEngine;

public class DamageCalculatorCritChance : IDamageCalculator
{
    private readonly CritWeaponConfig _weapon;

    public DamageCalculatorCritChance(CritWeaponConfig weapon)
    {
        _weapon = weapon;
    }

    public int CalculateDamage()
    {
        var chanceThrow = Random.Range(0f, 1f);
        var critRez = chanceThrow < _weapon.CritChance ? _weapon.CritDamageModifier : 1;
        return _weapon.Damage * critRez;
    }

    public string GetDescription()
    {
        return
            $"Damage: {_weapon.Damage}, CritChance: {_weapon.CritChance * 100}%, CritModifier: {_weapon.CritDamageModifier}";
    }
}