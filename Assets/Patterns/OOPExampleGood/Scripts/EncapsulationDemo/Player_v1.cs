using System;

namespace Patterns.OOPExampleGood.Scripts.EncapsulationDemo
{
    public class Player_v1 : ReadonlyPlayerV1
    {
        private double _health;
        private double _maxHealth;
        public override double Health => _health;
        public override double MaxHealth => _maxHealth;

        public Player_v1(double health, double maxHealth)
        {
            _health = health;
            _maxHealth = maxHealth;
        }
        
        public void AddHealth(double amount)
        {
            _health += amount;
            _health = Math.Min(_health, _maxHealth);
        }
        
        public void TakeDamage(double amount)
        {
            _health -= amount;
            _health = Math.Max(0, _health);
        }
    }
}