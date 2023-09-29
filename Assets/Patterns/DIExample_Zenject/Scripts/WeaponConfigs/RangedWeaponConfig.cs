using UnityEngine;

namespace Patterns.DIExample_Zenject.Scripts.WeaponConfigs
{
    /// <summary>
    /// Конфиг оружия c перепадом который бьёт рандомный урон от А до Б
    /// </summary>
    [CreateAssetMenu(fileName = "RangedWeaponConfig", menuName = "DIExample_Zenject/WeaponConfigs/RangedWeaponConfig", order = 1)]
    public class RangedWeaponConfig : ScriptableObject
    {
        [SerializeField] private int _minDamage;
        [SerializeField] private int _maxDamage;

        public int MinDamage => _minDamage;
        public int MaxDamage => _maxDamage;
    }
}