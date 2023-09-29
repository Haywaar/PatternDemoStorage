using System.Collections;
using Patterns.DIExample_Zenject.Scripts.Services.EnemyFactory;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Patterns.DIExample_Zenject.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnRoot;
        [SerializeField] private float _coolDown;
        [SerializeField] private float _prewarmTime;

        [SerializeField] private float _minXRadius;
        [SerializeField] private float _maxXRadius;
        [SerializeField] private float _minYRadius;
        [SerializeField] private float _maxYRadius;

         private int _killedMobsCount;

         public UnityAction<int> OnMobKilled;


        private EnemyFactory _factory;

        [Inject]
        private void Construct(EnemyFactory factory)
        {
            _factory = factory;
        }

        private void Start()
        {
            StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            yield return new WaitForSeconds(_prewarmTime);

            while (true)
            {
                CreateEnemy();
                yield return new WaitForSeconds(_coolDown);
            }
        }

        private void CreateEnemy()
        {
            var enemyPrefab = _factory.GetEnemyPrefab();
            var go = GameObject.Instantiate(enemyPrefab, _spawnRoot);
            go.Init(this);
            go.transform.position = CalculateSpawnPosition();
        }

        public void DestroyEnemy(Enemy enemy)
        {
            _killedMobsCount++;
            OnMobKilled?.Invoke(_killedMobsCount);
            Destroy(enemy.gameObject);
        }

        private Vector3 CalculateSpawnPosition()
        {
            // 1 or -1
            var xSign = (UnityEngine.Random.Range(0, 2) - 0.5f) * 2;
            var ySign = (UnityEngine.Random.Range(0, 2) - 0.5f) * 2;

            var randomX = UnityEngine.Random.Range(xSign * _minXRadius, xSign * _maxXRadius);
            var randomY = UnityEngine.Random.Range(ySign * _minYRadius, ySign * _maxYRadius);

            return _spawnRoot.transform.position + new Vector3(randomX, randomY, 0);
        }
    }
}