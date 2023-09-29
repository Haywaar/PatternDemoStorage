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