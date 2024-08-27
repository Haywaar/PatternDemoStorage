using UnityEngine;
using R3;
using TMPro;

public class TakeEventListener : MonoBehaviour
{
    [SerializeField] private SimpleEventInvoker _simpleEventInvoker;
    [SerializeField] private TextMeshProUGUI _buttonText;

    private int _counter = 0;
    private void Awake()
    {
        _simpleEventInvoker.OnSimpleR3Event
          .Take(5)
          .Subscribe(_ => OnSimpleR3Event())
          .AddTo(this);
    }

    private void OnSimpleR3Event()
    {
        _counter++;
        _buttonText.text = _counter.ToString();
    }
}
