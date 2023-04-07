using UnityEngine;

namespace Examples.AbstractFactoryExample.Unit.Knight
{
    public class RedKnight : Knight
    {
        [SerializeField] private float _redKnightKoef;
        public void Init(float redKnightKoef)
        {
            _redKnightKoef = redKnightKoef;
        }
        public override void Parry()
        {
            // do something
        }
    }
}