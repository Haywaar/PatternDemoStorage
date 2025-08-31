using System;
using UnityEngine;

namespace Patterns.OOPExampleGood.Scripts.EncapsulationDemo
{
    public class Player_v2
    {
        public double Health { get; private set; }
        public double MaxHealth { get; }
        public double Defense { get; private set; }

        public Player_v2(double health, double maxHealth, double defense)
        {
            Health = health;
            MaxHealth = maxHealth;
            Defense = defense;
        }

        public void AddHealth(double amount)
        {
            Health += amount;
            Health = Math.Min(Health, MaxHealth);
        }

        public void TakeDamage(double amount)
        {
            amount -= Defense;
            amount = Math.Max(0, amount);
            
            Health -= amount;
            Health = Math.Max(0, Health);
        }
    }
}