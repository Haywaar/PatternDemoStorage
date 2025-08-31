
using Patterns.MVCEncapsulated.SpinStrategy;
using Patterns.MVCEncapsulated.WinStrategy;

namespace Patterns.MVCEncapsulated.Model
{
    public class UnlimitedSpinsSlotMachineModel : SlotMachineModel
    {
        public UnlimitedSpinsSlotMachineModel(ISpinStrategy spinStrategy, IWinStrategy winStrategy) : base(spinStrategy, winStrategy)
        {
        }

        public override bool HaveSpins()
        {
            return true;
        }
    }
}
