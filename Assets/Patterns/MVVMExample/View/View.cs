using System.Collections.Generic;
using UnityEngine;

namespace Patterns.MVVMExample
{
    public abstract class View : MonoBehaviour
    {
        protected ViewModel _viewModel;

        public void Init(ViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.ViewStateChanged += DisplaySpinResult;
            _viewModel.ViewGoldChanged += DisplayGold;
            _viewModel.ViewIsWinChanged += DisplayYouWin;
        }

        protected abstract void DisplaySpinResult(List<int> state);
        protected abstract void DisplayYouWin(bool isWin);
        protected abstract void DisplayGold(int gold);

        protected virtual void Dispose()
        {
            _viewModel.ViewStateChanged -= DisplaySpinResult;
            _viewModel.ViewGoldChanged -= DisplayGold;
            _viewModel.ViewIsWinChanged -= DisplayYouWin;
        }

        protected void OnDestroy()
        {
            Dispose();
        }
    }
}