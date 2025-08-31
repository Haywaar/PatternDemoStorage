using System.Collections.Generic;

namespace Patterns.MVCEncapsulated.WinStrategy
{
    public class CentralLineWinStrategy : IWinStrategy
    {
        public bool IsWin(List<int> state)
        {
            bool isWin = state[3] == state[4] && state[3] == state[5];
            return isWin;
        }
    }
}