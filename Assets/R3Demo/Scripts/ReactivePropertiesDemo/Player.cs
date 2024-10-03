using UnityEngine;
using R3;

public class Player : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private int _maxHealth = 3;

    public float MovementSpeed => _movementSpeed;

    public readonly ReactiveProperty<int> Health = new();
    public ReadOnlyReactiveProperty<bool> IsDead;

    private void Awake()
    {
        Health.Value = _maxHealth;
        IsDead = Health.Select(x => x <= 0).ToReadOnlyReactiveProperty();
    }

    public void TakeDamage(int value)
    {
        var rezHealth = Health.Value - value;
        rezHealth = Mathf.Max(0, rezHealth);

        Health.Value = rezHealth;
    }

    public void AddHealth(int value)
    {
        var rezHealth = Health.Value + value;
        rezHealth = Mathf.Min(rezHealth, _maxHealth);

        Health.Value = rezHealth;
    }
}
