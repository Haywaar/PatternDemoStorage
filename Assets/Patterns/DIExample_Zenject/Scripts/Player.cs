using UnityEngine;
using Zenject;

namespace Patterns.DIExample_Zenject.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerInputController _playerInputController;
        
        [Inject]
        private IDamageCalculator _damageCalculator;
        [Inject]
        private DamageVisualizer _damageVisualizer;

        private void Awake()
        {
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
}