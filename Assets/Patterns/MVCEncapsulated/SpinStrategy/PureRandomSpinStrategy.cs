using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Patterns.MVCEncapsulated.SpinStrategy
{
    public class PureRandomSpinStrategy : ISpinStrategy
    {
        public List<int> Spin(int slotsCount)
        {
            List<int> tempState = new int[slotsCount].ToList();
            for (int i = 0; i < slotsCount; i++)
            {
               tempState[i] = Random.Range(0, 6);
            }
            
            return tempState;
        }
    }
}