using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.MVPExample
{
    public class SlotMachineUIView : View
    {
        [SerializeField] private List<Image> _slotValues;
        [SerializeField] private List<Sprite> _imagesByIds;
        [SerializeField] private Text _youWinText;
        [SerializeField] private Button _spinButton;
        private void Start()
        {
            _spinButton.onClick.AddListener((() =>
            {
                _presenter.OnSpinButtonClicked();
            }));
        }
        public void OnSlotClicked(int slotID)
        {
            _presenter.OnSlotClicked(slotID);
        }
        public override void DisplaySpinResult(List<int> values)
        {
            _youWinText.gameObject.SetActive(false);
            for (int i = 0; i < values.Count; i++)
            {
                _slotValues[i].sprite = GetImageById(values[i]);
            }
        }
        public override void DisplayYouWin()
        {
            _youWinText.gameObject.SetActive(true);
        }
        private Sprite GetImageById(int id)
        {
            return _imagesByIds[id];
        }
    }
}