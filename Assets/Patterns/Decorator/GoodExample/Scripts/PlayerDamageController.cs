using UnityEngine;

public class PlayerDamageController : MonoBehaviour
{
    [SerializeField] private float _startDamage;
    private DamageComponent _damageComponent;
    private DamageDecorator _damageDecorator;

    private void Awake()
    {
        _damageComponent = new DefaultDamageComponent(_startDamage);
        _damageDecorator = new DamageDecorator(_damageComponent);
    }

    public float GetDamageValue()
    {
        return _damageDecorator.GetDamage();
    }

    public void AddFixedDamage(float damage)
    {
        _damageDecorator = new AddFixedDamageDecorator(_damageDecorator, damage);
    }

    public void AddPercentBonusDamage(float addPercent)
    {
        _damageDecorator = new AddPercentageDamageDecorator(_damageDecorator, addPercent);
    }
}