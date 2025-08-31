using System.Collections.Generic;
using System.Linq;
using Patterns.MVCEncapsulated.SpinStrategy;
using Patterns.MVCEncapsulated.WinStrategy;

namespace Patterns.MVCEncapsulated.Model
{
   public abstract class SlotMachineModel
   {
      public List<int> State { get; private set; }

      // Для лимитных и безлимитных спинов
      public abstract bool HaveSpins();
      public int SpinsCount { get; private set; }

      public bool IsWin { get; private set; }
      
      private readonly ISpinStrategy _spinStrategy;
      private readonly IWinStrategy _winStrategy;

      public SlotMachineModel(ISpinStrategy spinStrategy, IWinStrategy winStrategy)
      {
         State = new int[9].ToList();
         _spinStrategy = spinStrategy;
         _winStrategy = winStrategy;
      }

      public void Spin()
      {
         State = _spinStrategy.Spin(State.Count);
         IsWin = _winStrategy.IsWin(State);
      }
   }
}
