using UnityEngine;

namespace Patterns.DIExample_Zenject.Scripts.Services.EnemyFactory
{
    public class SingleEnemyFactory : EnemyFactory
    {
        [SerializeField] private Enemy _enemy;
        
        public override Enemy GetEnemyPrefab()
        {
            return _enemy;
        }
    }
}