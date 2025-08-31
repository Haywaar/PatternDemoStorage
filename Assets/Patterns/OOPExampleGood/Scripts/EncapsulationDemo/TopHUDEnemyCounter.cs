using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.OOPExampleGood.Scripts.EncapsulationDemo
{
    public class TopHUDEnemyCounter : MonoBehaviour
    {
        [SerializeField] private Text _counterText;
        private EnemyController _enemyController;

        public void Init(EnemyController enemyController) 
        {
            _enemyController = enemyController;
        }
        
        private void Update()
        {
            var aliveEnemiesCount = _enemyController.GetAliveEnemiesCount();
            _counterText.text = "Enemies alive: " + aliveEnemiesCount;
        }
    }
}