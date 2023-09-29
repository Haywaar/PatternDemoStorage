using UnityEngine;

namespace Patterns.DIExample_Zenject.Scripts.WeaponConfigs
{
  /// <summary>
  /// Конфиг простого оружия который бьёт фиксированный урон
  /// </summary>
  [CreateAssetMenu(fileName = "SimpleWeaponConfig", menuName = "DIExample_Zenject/WeaponConfigs/SimpleWeaponConfig", order = 1)]
  public class SimpleWeaponConfig : ScriptableObject
  {
    [SerializeField] private int _damage;
    
    public int Damage => _damage;
  }
}
