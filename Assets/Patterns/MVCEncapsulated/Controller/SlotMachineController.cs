using Patterns.MVCEncapsulated.Model;
using Patterns.MVCEncapsulated.View;

namespace Patterns.MVCEncapsulated.Controller
{
   public class SlotMachineController
   {
      private readonly SlotMachineModel _model;
      private readonly SlotMachineView _view;

      public SlotMachineController(SlotMachineModel model, SlotMachineView view)
      {
         _model = model;
         _view = view;
      }

      public void Spin()
      {
         _model.Spin();
         _view.DisplaySpinResult(_model.State);
         _view.DisplayYouWinText(_model.IsWin);
      }
   }
}
