using Patterns.MVCEncapsulated.Controller;
using Patterns.MVCEncapsulated.Model;
using Patterns.MVCEncapsulated.SpinStrategy;
using Patterns.MVCEncapsulated.View;
using Patterns.MVCEncapsulated.WinStrategy;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Patterns.MVCEncapsulated
{
    public class SlotMachineBinder : MonoBehaviour
    {
        [SerializeField] private SlotMachine3DView _3dView;
        [SerializeField] private SlotMachineUIView _uiView;
        [SerializeField] private Button _spinButton;

        [SerializeField] private bool _is3D;
        [SerializeField] private bool _isOnlyCentralLineLogic; 
        
        private void Awake()
        {
            SlotMachineView viewPrefab = _is3D ? _3dView : _uiView;

            var view = Instantiate(viewPrefab);
            var spinStrategy = new PureRandomSpinStrategy();
            IWinStrategy winStrategy = _isOnlyCentralLineLogic ? new CentralLineWinStrategy() : new AllLinesWinStrategy();

            var model = new UnlimitedSpinsSlotMachineModel(spinStrategy, winStrategy);
            var controller = new SlotMachineController(model, view);
    
            _spinButton.onClick.AddListener((() =>
            {
                controller.Spin();
            }));
        }
    }
}