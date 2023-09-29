using UnityEngine;

namespace Patterns.DIExample_Zenject.Scripts.Services.EnemyFactory
{
    public abstract class EnemyFactory : MonoBehaviour
    {
        public abstract Enemy GetEnemyPrefab();
    }
}