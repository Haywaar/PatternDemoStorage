using UnityEngine;

namespace Patterns.MVPExample
{
    public class MainScript : MonoBehaviour
    {
        [SerializeField] private SlotMachine3DView _3dView;
        [SerializeField] private SlotMachineUIView _uiView;
        [SerializeField] private bool is3D;
        [SerializeField] private bool is3LineLogic;
        private void Awake()
        {
            View viewPrefab = is3D ? _3dView : _uiView;
            
            View view =  GameObject.Instantiate(viewPrefab);
            var model = new UnlimitedSpinsModel(view);
            Presenter presenter = is3LineLogic ? 
                new CentralLinePresenter(model) : 
                new AllLinesPresenter(model);
            
            view.Init(presenter);
        }
    }
}