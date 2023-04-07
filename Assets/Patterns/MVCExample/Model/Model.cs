using System.Collections.Generic;
using System.Linq;

public abstract class Model
{
   protected View _view;
   protected List<int> _state;
   public List<int> State => _state;

   // Для лимитных и безлимитных спинов
   public abstract bool HaveSpins();
   protected int _spinsCount;
   public int SpinsCount => _spinsCount;
   
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
}
