using UnityEngine;

namespace Patterns.DIExample.Scripts
{
    /// <summary>
    /// Конфиг оружия c перепадом который бьёт рандомный урон от А до Б
    /// </summary>
    [CreateAssetMenu(fileName = "RangedWeaponConfig", menuName = "DIExample/WeaponConfigs/RangedWeaponConfig", order = 1)]
    public class RangedWeaponConfig : ScriptableObject
    {
        [SerializeField] private int _minDamage;
        [SerializeField] private int _maxDamage;

        public int MinDamage => _minDamage;
        public int MaxDamage => _maxDamage;
    }
}