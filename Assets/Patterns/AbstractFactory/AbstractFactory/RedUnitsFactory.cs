using Examples.AbstractFactoryExample.Unit;
using Examples.AbstractFactoryExample.Unit.Archer;
using Examples.AbstractFactoryExample.Unit.Knight;
using UnityEngine;

namespace Examples.AbstractFactoryExample
{
    public class RedUnitsFactory : UnitsFactory
    {
        public override Knight CreateKnight()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/knight_red");
            var go = GameObject.Instantiate(prefab);
            var knight = go.GetComponent<RedKnight>();
            knight.Init(3.3f);
            return knight;
        }
        public override Mage CreateMage()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/mage_red");
            var go = GameObject.Instantiate(prefab);
            var mage = go.GetComponent<RedMage>();
            mage.Init(1.0f, 5.0f);
            return mage;
        }
        public override Archer CreateArcher()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/archer_red");
            var go = GameObject.Instantiate(prefab);
            var archer = go.GetComponent<RedArcher>();
            archer.Init(1.0f, 1.0f);
            return archer;
        }
    }
}