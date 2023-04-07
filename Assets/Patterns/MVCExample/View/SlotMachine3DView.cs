using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine3DView : View
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
