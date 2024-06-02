using UnityEngine;

public class PlayerDamageController : MonoBehaviour
{
    [SerializeField] private float _startDamage;
    private DamageComponent _damageComponent;

    private void Awake()
    {
        _damageComponent = new DefaultDamageComponent(_startDamage);
    }

    public float GetDamageValue()
    {
        return _damageComponent.GetDamage();
    }

    public void AddFixedDamage(float damage)
    {
        _damageComponent = new AddFixedDamageDecorator(_damageComponent, damage);
    }

    public void AddPercentBonusDamage(float addPercent)
    {
        _damageComponent = new AddPercentageDamageDecorator(_damageComponent, addPercent);
    }
}