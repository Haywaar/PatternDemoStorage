using UnityEngine;

namespace Patterns.MVVMExample
{
    public class SlotMachine3DSlot : MonoBehaviour
    {
        [SerializeField] private int _slotID;
        public int SlotID => _slotID;
    }
}