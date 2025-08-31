using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.MVCEncapsulated.View
{
    public class SlotMachine3DView : SlotMachineView
    {
        [SerializeField] private List<MeshRenderer> _slotValues;
        [SerializeField] private List<Material> _materials;
        [SerializeField] private Text _youWinText;
        public override void DisplaySpinResult(List<int> values)
        {
            for (int i = 0; i < values.Count; i++)
            {
                _slotValues[i].material = GetMaterialById(values[i]);
            }
        }
        public override void DisplayYouWinText(bool isActive)
        {
            _youWinText.gameObject.SetActive(isActive);
        }
        private Material GetMaterialById(int val)
        {
            return _materials[val];
        }
    }
}
