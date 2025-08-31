using System.Collections.Generic;
using UnityEngine;

namespace Patterns.MVCEncapsulated.View
{
    public abstract class SlotMachineView : MonoBehaviour
    {
        public abstract void DisplaySpinResult(List<int> values);
        public abstract void DisplayYouWinText(bool isActive);
    }
}
