using System.Linq;
using System.Collections;
using UnityEngine;

namespace Patterns.OOPExampleGood.Scripts.EncapsulationDemo
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Transform _spawnRoot;
        [SerializeField] private int _spawnInterval = 1;
        private EnemyController _enemyController;
        private void Awake()
        {
            StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnInterval);
                var aliveEnemiesCount = _enemyController.Enemies.Count(e => !e.IsDead());
                if (aliveEnemiesCount < 150)
                {
                    CreateEnemy();
                }
            }
        }

        private void CreateEnemy()
        {
            var enemy = Instantiate(_enemyPrefab, _spawnRoot.position, Quaternion.identity);
            _enemyController.OnNewEnemyCreated(enemy);
        }
    }
}