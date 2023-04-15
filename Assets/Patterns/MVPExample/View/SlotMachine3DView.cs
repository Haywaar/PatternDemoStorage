using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.MVPExample
{
    public class SlotMachine3DView : View
    {
        [SerializeField] private List<MeshRenderer> _slotValues;
        [SerializeField] private List<Material> _materials;
        [SerializeField] private Text _youWinText;
        [SerializeField] private Material _selectedMaterial;
        [SerializeField] private Button _spinButton;

        private void Start()
        {
            _spinButton.onClick.AddListener(_presenter.OnSpinButtonClicked);
        }
        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                HandleClick();
            }
        }
        private void HandleClick()
        {
            RaycastHit hit; 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                var slot = hit.collider.GetComponent<SlotMachine3DSlot>();
                if (slot != null)
                {
                    _presenter.OnSlotClicked(slot.SlotID);
                }
            }
        }
        public override void DisplaySpinResult(List<int> values)
        {
            _youWinText.gameObject.SetActive(false);
            for (int i = 0; i < values.Count; i++)
            {
                _slotValues[i].material = GetMaterialById(values[i]);
            }
        }
        public override void DisplayYouWin()
        {
            _youWinText.gameObject.SetActive(true);
        }
        private Material GetMaterialById(int val)
        {
            return _materials[val];
        }
       
    }
}