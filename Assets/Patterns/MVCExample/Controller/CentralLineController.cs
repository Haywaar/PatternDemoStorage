
using System.Collections.Generic;

public class CentralLineController : Controller
{
    public CentralLineController(Model model) : base(model)
    {
    }
    protected override bool AnalyzeWinResult(List<int> state)
    {
        bool isWin = state[3] == state[4] && state[3] == state[5];
        return isWin;
    }
}






