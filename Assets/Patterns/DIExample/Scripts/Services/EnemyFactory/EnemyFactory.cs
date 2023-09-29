using UnityEngine;

namespace Patterns.DIExample.Scripts.Services.EnemyFactory
{
    public abstract class EnemyFactory : MonoBehaviour
    {
        public abstract Enemy GetEnemyPrefab();
    }
}