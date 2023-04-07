using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Controller
{
   protected View _view;
   protected Model _model;

   public Controller(View view, Model model)
   {
      _view = view;
      _model = model;
   }

   // Его тоже можно запилить абстрактным,
   // если у нас будет не чистый рандом а разные варианты
   public void Spin()
   {
      List<int> tempState = new int[_model.State.Count].ToList();
      for (int i = 0; i < _model.State.Count; i++)
      {
         tempState[i] = Random.Range(0, 6);
      }

      _model.SetState(tempState);
      AnalyzeResult();
   }

   protected abstract void AnalyzeResult();
}
