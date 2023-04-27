using UnityEngine;

namespace Patterns.MVVMExample_Simple
{
    public abstract class View : MonoBehaviour
    {
        protected ViewModel _viewModel;

        public virtual void Init(ViewModel viewModel)
        {
            _viewModel = viewModel;

            // Подписка на изменение STR,DEX и VIT
            _viewModel.StrView.OnChanged += DisplayStrView;
            _viewModel.DexView.OnChanged += DisplayDexView;
            _viewModel.VitView.OnChanged += DisplayVitView;

            _viewModel.StatsToSpendView.OnChanged += DisplayStatsToSpend;

            // Подписка на изменение состояния кнопок
            _viewModel.StrButtonEnabled.OnChanged += OnStrButtonEnabled;
            _viewModel.DexButtonEnabled.OnChanged += OnDexButtonEnabled;
            _viewModel.VitButtonEnabled.OnChanged += OnVitButtonEnabled;
        }

        // Команды на активацию кнопок
        protected abstract void OnStrButtonEnabled(bool val);
        protected abstract void OnDexButtonEnabled(bool val);
        protected abstract void OnVitButtonEnabled(bool val);

        // Команды на отрисовку значений
        protected abstract void DisplayStatsToSpend(int val);
        protected abstract void DisplayStrView(int val);
        protected abstract void DisplayDexView(int val);
        protected abstract void DisplayVitView(int val);

        protected virtual void Dispose()
        {
            // Отписка от изменений STR,DEX и VIT
            _viewModel.StrView.OnChanged -= DisplayStrView;
            _viewModel.DexView.OnChanged -= DisplayDexView;
            _viewModel.VitView.OnChanged -= DisplayVitView;

            _viewModel.StatsToSpendView.OnChanged -= DisplayStatsToSpend;

            // Отписка от изменений состояния кнопок
            _viewModel.StrButtonEnabled.OnChanged -= OnStrButtonEnabled;
            _viewModel.DexButtonEnabled.OnChanged -= OnDexButtonEnabled;
            _viewModel.VitButtonEnabled.OnChanged -= OnVitButtonEnabled;
        }

        protected void OnDestroy()
        {
            Dispose();
        }
    }
}