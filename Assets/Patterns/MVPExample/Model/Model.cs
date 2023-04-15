using System.Collections.Generic;
using System.Linq;
using Patterns.MVPExample;

namespace Patterns.MVPExample
{
    public abstract class Model
    {
        protected View _view;
        protected List<int> _state;
        protected bool _isWin;
        public List<int> State => _state;

        public Model(View view)
        {
            _view = view;
            _state = new int[9].ToList();
        }

        public void SetState(List<int> newState)
        {
            _state = newState;
            _view.DisplaySpinResult(_state);
        }

        public void SetStateWin(bool isWin)
        {
            _isWin = isWin;
            if (_isWin)
            {
                _view.DisplayYouWin();
            }
        }
    }
}