using UnityEngine;
using System;

public class SimplePlayer
{
    public int _health;
    public event Action<int> OnHealthChanged;

    public void SubstractHealth(int value)
    {
        _health -= value;
        _health = Mathf.Max(0, _health);
        OnHealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            // Player Dead
        }
    }
}

