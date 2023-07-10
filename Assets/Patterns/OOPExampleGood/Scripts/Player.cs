using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _gold;
    
    public int Health => _health;
    public int MaxHealth => _maxHealth;
    public int Gold => _gold;

    public void AddHealth(int delta)
    {
        if (delta <= 0)
        {
            Debug.LogError("Something wrong with delta! Must be > 0!");
            return;
        }

        _health += delta;
        _health = Mathf.Min(_health, _maxHealth);
    }
    
    public void RemoveHealth(int delta)
    {
        if (delta <= 0)
        {
            Debug.LogError("Something wrong with delta! Must be > 0!");
            return;
        }

        _health -= delta;
        _health = Mathf.Max(0, _health);

        if (_health == 0)
        {
            Debug.Log("You dead!");
        }
    }
}
