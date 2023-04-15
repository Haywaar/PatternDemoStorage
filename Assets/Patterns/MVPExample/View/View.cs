using System.Collections.Generic;
using UnityEngine;

namespace Patterns.MVPExample
{
    public abstract class View : MonoBehaviour
    {
        protected Presenter _presenter;

        public void Init(Presenter presenter)
        {
            _presenter = presenter;
        }

        public abstract void DisplaySpinResult(List<int> values);
        public abstract void DisplayYouWin();
    }
}