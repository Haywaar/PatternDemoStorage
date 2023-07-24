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

   protected bool _isWin;

   public bool IsWin => _isWin;

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

   public void SetWinState(bool isWin)
   {
      _isWin = isWin;
      _view.DisplayYouWinText(_isWin);
   }
}
