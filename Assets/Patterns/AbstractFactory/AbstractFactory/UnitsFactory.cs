using Examples.AbstractFactoryExample.Unit;
using Examples.AbstractFactoryExample.Unit.Archer;
using Examples.AbstractFactoryExample.Unit.Knight;

namespace Examples.AbstractFactoryExample
{
    public abstract class UnitsFactory
    {
        public abstract Knight CreateKnight();
        public abstract Mage CreateMage();
        public abstract Archer CreateArcher();
    }
}