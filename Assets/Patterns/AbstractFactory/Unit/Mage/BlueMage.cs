using UnityEngine;

namespace Examples.AbstractFactoryExample.Unit
{
    public class BlueMage : Mage
    {
        [SerializeField] private float _slowKoef;

        public void Init(float slowKoef)
        {
            _slowKoef = slowKoef;
        }

        public override void CastSpell()
        {
            // Casting Blizzard
        }
    }
}