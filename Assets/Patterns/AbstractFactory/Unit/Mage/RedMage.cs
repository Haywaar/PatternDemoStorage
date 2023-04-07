using UnityEngine;

namespace Examples.AbstractFactoryExample.Unit
{
    public class RedMage : Mage
    {
        [SerializeField] private float _fireBallRadius;
        [SerializeField] private float _fireBallDamage;
        public void Init(float fireBallRadius, float fireBallDamage)
        {
            _fireBallRadius = fireBallRadius;
            _fireBallDamage = fireBallDamage;
        }
        public override void CastSpell()
        {
            //Casting Fireball
        }
    }
}