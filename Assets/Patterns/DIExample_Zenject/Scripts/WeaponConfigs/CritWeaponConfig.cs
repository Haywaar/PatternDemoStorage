using UnityEngine;

namespace Patterns.DIExample_Zenject.Scripts.WeaponConfigs
{
    /// <summary>
    /// Конфиг простого оружия с вероятностью крита
    /// </summary>
    [CreateAssetMenu(fileName = "CritWeaponConfig", menuName = "DIExample_Zenject/WeaponConfigs/CritWeaponConfig", order = 1)]
    public class CritWeaponConfig : ScriptableObject
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _critChance;
        [SerializeField] private int _critDamageModifier;

        public int Damage => _damage;
        public float CritChance => _critChance;
        public int CritDamageModifier => _critDamageModifier;
    }
}