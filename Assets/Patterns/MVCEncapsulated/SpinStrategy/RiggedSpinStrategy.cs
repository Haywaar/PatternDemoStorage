using System.Collections.Generic;
using System.Linq;

namespace Patterns.MVCEncapsulated.SpinStrategy
{
    public class RiggedSpinStrategy : ISpinStrategy
    {
        public List<int> Spin(int slotsCount)
        {
            List<int> tempState = new int[slotsCount].ToList();
            for (int i = 0; i < slotsCount; i++)
            {
                tempState[i] = 1;
            }

            return tempState;
        }
    }
}