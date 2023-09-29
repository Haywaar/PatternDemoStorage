using UnityEngine;

/// <summary>
/// Конфиг простого оружия который бьёт фиксированный урон
/// </summary>
[CreateAssetMenu(fileName = "SimpleWeaponConfig", menuName = "DIExample/WeaponConfigs/SimpleWeaponConfig", order = 1)]
public class SimpleWeaponConfig : ScriptableObject
{
  [SerializeField] private int _damage;
    
  public int Damage => _damage;
}
