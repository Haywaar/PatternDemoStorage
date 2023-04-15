using System.Collections.Generic;

namespace Patterns.MVPExample
{
    public class CentralLinePresenter : Presenter
    {
        protected override bool AnalyzeResult()
        {
            var state = _model.State;
            bool isWin = state[3] == state[4] && state[3] == state[5];

            return isWin;
        }

        public CentralLinePresenter(Model model) : base(model)
        {
        }
    }
}