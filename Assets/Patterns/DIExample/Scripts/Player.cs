using Patterns.DIExample.Scripts;
using Patterns.DIExample.Scripts.PlayerInput;
using Patterns.DIExample.Scripts.Services.DamageVisualizer;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInputController _playerInputController;
    private IDamageCalculator _damageCalculator;
    private DamageVisualizer _damageVisualizer;

    public void Construct(IDamageCalculator damageCalculator, DamageVisualizer damageVisualizer, InputHandler handler)
    {
        _damageCalculator = damageCalculator;
        _damageVisualizer = damageVisualizer;
        _playerInputController.Construct(handler);
        _playerInputController.EnemyAttackRequest += OnEnemyAttackRequest;
    }

    private void OnEnemyAttackRequest(Enemy enemy)
    {
        Attack(enemy);
    }

    private void Attack(Enemy enemy)
    {
        float damage = _damageCalculator.CalculateDamage();
        _damageVisualizer.Visualize(damage.ToString(), enemy.transform);
        enemy.RemoveHealth(damage);
    }
}