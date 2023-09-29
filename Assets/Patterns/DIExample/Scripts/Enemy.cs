using System;
using DG.Tweening;
using Patterns.DIExample.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _health = 3;

    private EnemySpawner _spawner;
    
    public void Init(EnemySpawner spawner)
    {
        _spawner = spawner;
    }

    private Tween _tween;

    public void RemoveHealth(float damageValue)
    {
        _health -= damageValue;
        _health = Mathf.Max(0, _health);

        if (_health <= 0)
        {
            _tween.Kill();
            _spawner.DestroyEnemy(this);
        }
        else
        {
            Shake();
        }
    }

    private void Shake()
    {
        _tween = _image.transform.DOShakePosition(0.5f, 15, 15, 11);
    }
}