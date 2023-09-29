using UnityEngine;
using Zenject;

namespace Patterns.DIExample_Zenject.Scripts
{
    public class TestLogScript : ITickable, ILateTickable, IFixedTickable
    {
        public void Tick()
        {
            //  Debug.LogWarning("update");
        }

        public void LateTick()
        {
            //   Debug.LogWarning("late update");
        }

        public void FixedTick()
        {
            //  Debug.LogWarning("fixed update");
        }
    }
}