using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace Patterns.MVVMExample
{
    public abstract class ViewModel
    {
        protected Model _model;

        protected List<int> _viewState;
        public Action<List<int>> ViewStateChanged;

        protected bool _isWin;
        public Action<bool> ViewIsWinChanged;

        protected int _viewGoldVal;
        public Action<int> ViewGoldChanged;

        protected bool _isRerollModeOn;
        public Action<bool> RerollModeChanged;

        public ViewModel(Model model)
        {
            _model = model;
            _model.StateChanged += OnStateChanged;
            _model.GoldChanged += OnGoldChanged;
            _model.IsWinChanged += OnIsWinChanged;
        }

        public void SetRerollMode(bool active)
        {
            _isRerollModeOn = active;

            // Если мы отжимаем RerollMode, то считаем это как спин с текущей датой
            if (!_isRerollModeOn)
            {
                Spin(_viewState);
            }

            RerollModeChanged?.Invoke(_isRerollModeOn);
        }

        public void SpinButtonClicked()
        {
            if (!_isRerollModeOn)
            {
                Spin(CalculateSpinResult());
            }
        }

        public void SlotClicked(int slotId)
        {
            if (_isRerollModeOn)
            {
                RerollSlot(slotId);
            }
        }

        protected void Spin(List<int> spinData)
        {
            _viewState = spinData;
            _model.SetState(_viewState);
            _isWin = AnalyzeResult();
            _model.SetStateWin(AnalyzeResult());
            if (_isWin)
            {
                _model.AddGold(10);
            }
        }

        /// <summary>
        /// Пока делаем рандомчик, в случае чего можно сделать
        /// метод абстрактным если логика будет разной
        /// </summary>
        /// <returns></returns>
        protected List<int> CalculateSpinResult()
        {
            List<int> tempState = new int[_model.State.Count].ToList();
            for (int i = 0; i < _model.State.Count; i++)
            {
                tempState[i] = Random.Range(0, 6);
            }

            return tempState;
        }

        /// <summary>
        /// Пока делаем рандомчик, в случае чего можно сделать
        /// метод абстрактным если логика будет разной
        /// </summary>
        /// <returns></returns>
        protected void RerollSlot(int slotId)
        {
            var tempState = _viewState;
            var slotValue = Random.Range(0, 6);
            tempState[slotId] = slotValue;

            _viewState = tempState;
            ViewStateChanged?.Invoke(_viewState);
        }

        protected abstract bool AnalyzeResult();
        
        private void OnStateChanged(List<int> state)
        {
            _viewState = state;
            ViewStateChanged?.Invoke(_viewState);
        }
        private void OnGoldChanged(int val)
        {
            _viewGoldVal = val;
            ViewGoldChanged?.Invoke(_viewGoldVal);
        }
        private void OnIsWinChanged(bool isWin)
        {
            _isWin = isWin;
            ViewIsWinChanged?.Invoke(isWin);
        }
    }
}