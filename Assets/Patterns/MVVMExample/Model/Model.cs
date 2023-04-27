using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns.MVVMExample
{
    public abstract class Model
    {
        protected List<int> _state;
        public List<int> State => _state;
        public Action<List<int>> StateChanged;

        private int _gold;
        public int Gold => _gold;
        public Action<int> GoldChanged;

        protected bool _isWin;
        public Action<bool> IsWinChanged;

        public Model()
        {
            _state = new int[9].ToList();
        }

        public void SetStateWin(bool isWin)
        {
            _isWin = isWin;
            IsWinChanged(_isWin);
        }

        public void SetState(List<int> newState)
        {
            _state = newState;
            StateChanged?.Invoke(_state);
        }

        public void AddGold(int addVal)
        {
            _gold += addVal;
            GoldChanged?.Invoke(_gold);
        }
    }
}
