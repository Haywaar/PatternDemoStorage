using System.Linq;
using UnityEngine;

namespace Patterns.OOPExampleGood.Scripts.EncapsulationDemo
{
    public class AchievementTracker : MonoBehaviour
    {
        private EnemyController _enemyController;
        private bool _is100EnemiesAchieved;
        
        public void Init(EnemyController enemyController, bool is100EnemiesAchieved)
        {
            _enemyController = enemyController;
            _is100EnemiesAchieved = is100EnemiesAchieved;
        }

        private void Update()
        {
            var aliveEnemiesCount = _enemyController.Enemies.Count(e => !e.IsDead());
            if (aliveEnemiesCount >= 100 && !_is100EnemiesAchieved)
            {
                _is100EnemiesAchieved = true;
                Debug.Log("100 enemies achieved!"); // show achievement popup
            }
        }
    }
}