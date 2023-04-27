using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.MVVMExample
{
    public class SlotMachineUIView : View
    {
        [SerializeField] private List<Image> _slotValues;
        [SerializeField] private List<Sprite> _imagesByIds;
        [SerializeField] private Text _youWinText;
        [SerializeField] private Button _spinButton;
        [SerializeField] private Text _goldCountText;
        [SerializeField] private Toggle _rerollModeToggle;
        
        private void Start()
        {
            _spinButton.onClick.AddListener((() =>
            {
                _viewModel.SpinButtonClicked();
            }));
            
            _rerollModeToggle.onValueChanged.AddListener(OnToggleValueChanged);
        }

        public void OnSlotClicked(int slotID)
        {
            _viewModel.SlotClicked(slotID);
        }
        protected override void DisplaySpinResult(List<int> values)
        {
            _youWinText.gameObject.SetActive(false);
            for (int i = 0; i < values.Count; i++)
            {
                _slotValues[i].sprite = GetImageById(values[i]);
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

        private void OnToggleValueChanged(bool value)
        {
            _viewModel.SetRerollMode(value);
        }

        private Sprite GetImageById(int id)
        {
            return _imagesByIds[id];
        }
    }
}