using UnityEngine;
using UnityEngine.UI;

namespace Patterns.MVVMExample_Simple
{
    public class DefaultView : View
    {
        [SerializeField] private Text _strValText;
        [SerializeField] private Text _dexValText;
        [SerializeField] private Text _vitValText;
        [SerializeField] private Text _statsToSpendValText;

        [SerializeField] private Button _addStrButton;
        [SerializeField] private Button _addDexButton;
        [SerializeField] private Button _addVitButton;

        [SerializeField] private Sprite _activeBtnSprite;
        [SerializeField] private Sprite _inactiveBtnSprite;

        [SerializeField] private Button _resetButton;
        [SerializeField] private Button _submitButton;

        public override void Init(ViewModel viewModel)
        {
            base.Init(viewModel);

            // Обработка нажатия на кнопок "+"
            _addStrButton.onClick.AddListener(_viewModel.OnIncreaseStrBtnClicked);
            _addDexButton.onClick.AddListener(_viewModel.OnIncreaseDexBtnClicked);
            _addVitButton.onClick.AddListener(_viewModel.OnIncreaseVitBtnClicked);

            // Обработка нажатия на кнопки RESET и SUBMIT
            _resetButton.onClick.AddListener(_viewModel.OnResetButtonClicked);
            _submitButton.onClick.AddListener(_viewModel.OnSubmitBtnClicked);

            _strValText.text = _viewModel.StrView.Value.ToString();
            _dexValText.text = _viewModel.DexView.Value.ToString();
            _vitValText.text = _viewModel.VitView.Value.ToString();
        }

        protected override void OnStrButtonEnabled(bool val)
        {
            OnBtnEnabled(_addStrButton, val);
        }

        protected override void OnDexButtonEnabled(bool val)
        {
            OnBtnEnabled(_addDexButton, val);
        }

        protected override void OnVitButtonEnabled(bool val)
        {
            OnBtnEnabled(_addVitButton, val);
        }

        private void OnBtnEnabled(Button button, bool val)
        {
            button.enabled = val;
            button.image.sprite = val ? _activeBtnSprite : _inactiveBtnSprite;
        }

        protected override void DisplayStatsToSpend(int val)
        {
            _statsToSpendValText.text = val.ToString();
        }

        protected override void DisplayStrView(int val)
        {
            _strValText.text = val.ToString();
        }

        protected override void DisplayDexView(int val)
        {
            _dexValText.text = val.ToString();
        }

        protected override void DisplayVitView(int val)
        {
            _vitValText.text = val.ToString();
        }
    }
}