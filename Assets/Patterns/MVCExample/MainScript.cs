using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
  [SerializeField] private SlotMachine3DView _3dView;
  [SerializeField] private SlotMachineUIView _uiView;
  [SerializeField] private Button _spinButton;

  [SerializeField] private bool is3D;
  [SerializeField] private bool isOnlyCentralLineLogic;
  
  private void Awake()
  {
    View viewPrefab = is3D ? _3dView : _uiView;

    var view = Instantiate(viewPrefab);
    Model model = new UnlimitedSpinsModel(view);
    Controller controller = isOnlyCentralLineLogic ? new CentralLineController(view, model) : new AllLinesController(view,model);

    
    _spinButton.onClick.AddListener((() =>
    {
      controller.Spin();
    }));
  }
}
