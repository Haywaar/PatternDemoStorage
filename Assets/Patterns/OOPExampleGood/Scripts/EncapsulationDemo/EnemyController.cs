using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Patterns.OOPExampleGood.Scripts.EncapsulationDemo
{
    public class EnemyController : MonoBehaviour
    {
        public List<Enemy> Enemies { get; private set; }

        public EnemyController(List<Enemy> enemies)
        {
            Enemies = enemies;
        }
        
        public int GetAliveEnemiesCount()
        {
            return Enemies.Count(e => !e.IsDead());
        }
        
        public void StartGame()
        {
            // start spawning enemies
        }

        public void OnPlayerDead()
        {
            //stop enemies
        }

        public void OnNewEnemyCreated(Enemy enemy)
        {
            Enemies.Add(enemy);
        }
        
        public void OnEnemyDead(Enemy enemy)
        {
            Destroy(enemy.gameObject);
            Enemies.Remove(enemy);
        }
    }
}