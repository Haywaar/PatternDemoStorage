using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using System;

public class R3ObservableScript : MonoBehaviour
{
    private CompositeDisposable _disposables = new CompositeDisposable();

    private void Start()
    {
        Observable
        .Interval(TimeSpan.FromSeconds(1.0f))
        .Subscribe(_ => Debug.Log("Timer")
        ).AddTo(_disposables);
    }

    private void OnDestroy()
    {
        _disposables.Dispose();
    }
}


public class Player
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

public class HealthBar : MonoBehaviour
{
    public Player _player;

    private void Awake()
    {
        _player.OnHealthChanged += DrawHealth;
    }

    private void DrawHealth(int health)
    {
        // Draw health
    }
}

