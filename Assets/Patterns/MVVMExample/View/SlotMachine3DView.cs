using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.MVVMExample
{
    public class SlotMachine3DView : View
    {
        [SerializeField] private List<MeshRenderer> _slotValues;
        [SerializeField] private List<Material> _materials;
        [SerializeField] private Text _youWinText;
        [SerializeField] private Button _spinButton;
        [SerializeField] private Text _goldCountText;
        [SerializeField] private Toggle _rerollModeToggle;
        private void Start()
        {
            _spinButton.onClick.AddListener(_viewModel.SpinButtonClicked);
            
            _rerollModeToggle.onValueChanged.AddListener(OnToggleValueChanged);
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
                    _viewModel.SlotClicked(slot.SlotID);
                }
            }
        }
        protected override void DisplaySpinResult(List<int> values)
        {
            _youWinText.gameObject.SetActive(false);
            for (int i = 0; i < values.Count; i++)
            {
                _slotValues[i].material = GetMaterialById(values[i]);
            }
        }
        protected override void DisplayYouWin(bool isWin)
        {
            _youWinText.gameObject.SetActive(isWin);
        }

        protected override void DisplayGold(int gold)
        {
            _goldCountText.text = "Gold: " + gold;
        }

        private Material GetMaterialById(int val)
        {
            return _materials[val];
        }
        
        private void OnToggleValueChanged(bool value)
        {
            _viewModel.SetRerollMode(value);
        }
        
    }
}