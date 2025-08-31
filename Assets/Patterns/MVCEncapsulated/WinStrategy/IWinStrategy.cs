using System.Collections.Generic;

namespace Patterns.MVCEncapsulated.WinStrategy
{
    public interface IWinStrategy
    {
        public bool IsWin(List<int> state);
    }
}