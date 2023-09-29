using Patterns.DIExample_Zenject.Scripts.WeaponConfigs;

namespace Patterns.DIExample_Zenject.Scripts.Services.Calculator.DamageCalculators
{
    public class DamageCalculatorSimple : IDamageCalculator
    {
        private readonly SimpleWeaponConfig _weapon;

        public DamageCalculatorSimple(SimpleWeaponConfig weapon)
        {
            _weapon = weapon;
        }

        public int CalculateDamage()
        {
            return _weapon.Damage;
        }

        public string GetDescription()
        {
            return $"Damage: {_weapon.Damage}";
        }
    }
}