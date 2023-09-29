using Patterns.DIExample_Zenject.Scripts.WeaponConfigs;
using UnityEngine;

namespace Patterns.DIExample_Zenject.Scripts.Services.Calculator.DamageCalculators
{
    public class DamageCalculatorRange : IDamageCalculator
    {
        private readonly RangedWeaponConfig _weapon;

        public DamageCalculatorRange(RangedWeaponConfig weapon)
        {
            _weapon = weapon;
        }

        public int CalculateDamage()
        {
            return Random.Range(_weapon.MinDamage, _weapon.MaxDamage);
        }
    
        public string GetDescription()
        {
            return $"Random range from {_weapon.MinDamage} to {_weapon.MaxDamage}";
        }
    }
}