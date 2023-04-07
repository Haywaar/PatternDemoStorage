using Examples.AbstractFactoryExample.Unit;
using Examples.AbstractFactoryExample.Unit.Archer;
using Examples.AbstractFactoryExample.Unit.Knight;
using UnityEngine;

namespace Examples.AbstractFactoryExample
{
    public class BlueUnitsFactory : UnitsFactory
    {
        public override Knight CreateKnight()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/knight_blue");
            var go = GameObject.Instantiate(prefab);
            var knight = go.GetComponent<BlueKnight>();
            knight.Init(4.0f, 2.0f);
            
            return knight;
        }

        public override Mage CreateMage()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/mage_blue");
            var go = GameObject.Instantiate(prefab);
            var mage = go.GetComponent<BlueMage>();
            mage.Init(5.0f);
            
            return mage;
        }

        public override Archer CreateArcher()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/archer_blue");
            var go = GameObject.Instantiate(prefab);
            var archer = go.GetComponent<BlueArcher>();
            
            return archer;
        }
    }
}