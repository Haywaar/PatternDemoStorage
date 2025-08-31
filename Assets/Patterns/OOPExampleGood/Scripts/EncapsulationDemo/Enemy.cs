using UnityEngine;

namespace Patterns.OOPExampleGood.Scripts.EncapsulationDemo
{
    public class Enemy : MonoBehaviour
    {
        public double Health { get; private set; }
        
        public bool IsDead()
        {
            return Health <= 0;
        }
    }
}