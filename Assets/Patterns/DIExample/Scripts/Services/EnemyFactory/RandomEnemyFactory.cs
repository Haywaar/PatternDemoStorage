using System.Collections.Generic;
using UnityEngine;

namespace Patterns.DIExample.Scripts.Services.EnemyFactory
{
    public class RandomEnemyFactory : EnemyFactory
    {
        [SerializeField] private List<Enemy> _enemies;
        
        public override Enemy GetEnemyPrefab()
        {
            var index = Random.Range(0, _enemies.Count);
            return _enemies[index];
        }
    }
}