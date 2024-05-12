using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageController : MonoBehaviour
{
    [SerializeField] private float _startDamage;
    private List<DamageComponent> _damageComponents = new List<DamageComponent>();

    private void Awake()
    {
        _damageComponents.Add(new DamageComponent(DamageComponentType.FixedValue, _startDamage));
    }

    public float GetDamageValue()
    {
        float damage = 0f;
        for (int i = 0; i < _damageComponents.Count; i++)
        {
            switch (_damageComponents[i].DamageComponentType)
            {
                case DamageComponentType.FixedValue:
                    damage += _damageComponents[i].Value;
                    break;
                case DamageComponentType.PercentBonus:
                    damage += damage * _damageComponents[i].Value;
                    break;
            }
        }
        return damage;
    }

    public void AddFixedDamage(float damage)
    {
        _damageComponents.Add(new DamageComponent(DamageComponentType.FixedValue, damage));
    }

    public void AddPercentBonusDamage(float addPercent)
    {
        _damageComponents.Add(new DamageComponent(DamageComponentType.PercentBonus, addPercent));
    }
}