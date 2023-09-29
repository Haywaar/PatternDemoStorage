using UnityEngine;
using Zenject;

namespace Patterns.DIExample_Zenject.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerInputController _playerInputController;
        
        private IDamageCalculator _damageCalculator;
        private DamageVisualizer _damageVisualizer;

        [Inject]
        private void Construct(IDamageCalculator damageCalculator, DamageVisualizer damageVisualizer)
        {
            _damageCalculator = damageCalculator;
            _damageVisualizer = damageVisualizer;
            
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