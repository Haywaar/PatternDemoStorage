using System.Collections.Generic;

namespace Patterns.MVCEncapsulated.SpinStrategy
{
    public interface ISpinStrategy
    {
        public List<int> Spin(int slotsCount);
    }
}