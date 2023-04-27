using System.Collections.Generic;

namespace Patterns.MVVMExample
{
    public class CentralLineViewModel : ViewModel
    {
        public CentralLineViewModel(Model model) : base(model)
        {
        }
        
        protected override bool AnalyzeResult()
        {
            var state = _model.State;
            bool isWin = state[3] == state[4] && state[3] == state[5];

            return isWin;
        }
    }
}