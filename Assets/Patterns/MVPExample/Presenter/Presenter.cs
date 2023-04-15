using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Patterns.MVPExample
{
    public abstract class Presenter
    {
        protected Model _model;
        public Presenter(Model model)
        {
            _model = model;
        }

        public void OnSpinButtonClicked()
        {
            Spin();
        }

        public void OnSlotClicked(int slotId)
        {
            RerollSlot(slotId);
        }

        // Его тоже можно запилить абстрактным,
        // если у нас будет не чистый рандом а разные варианты
        protected void Spin()
        {
            List<int> tempState = new int[_model.State.Count].ToList();
            for (int i = 0; i < _model.State.Count; i++)
            {
                tempState[i] = Random.Range(0, 6);
            }

            _model.SetState(tempState);
            _model.SetStateWin(AnalyzeResult());
        }

        protected void RerollSlot(int slotId)
        {
            var tempState = _model.State;
            var slotValue = Random.Range(0, 6);
            tempState[slotId] = slotValue;

            _model.SetState(tempState);
            _model.SetStateWin(AnalyzeResult());
        }

        protected abstract bool AnalyzeResult();
    }
}