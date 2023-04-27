using UnityEngine;

namespace Patterns.MVVMExample
{
    public class MainScript : MonoBehaviour
    {
        [SerializeField] private SlotMachine3DView _3dView;
        [SerializeField] private SlotMachineUIView _uiView;
        
        [SerializeField] private bool is3D;
        [SerializeField] private bool is3LineLogic;
        
        private void Start()
        {
            var model = new UnlimitedSpinsModel();
            var viewModel = new AllLinesViewModel(model);
            
            View viewPrefab = is3D ? _3dView : _uiView;
            View view =  GameObject.Instantiate(viewPrefab);
            view.Init(viewModel);
        }
    }
}