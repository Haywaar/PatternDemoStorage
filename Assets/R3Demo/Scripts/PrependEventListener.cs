using UnityEngine;
using R3;
using TMPro;

public class PrependEventListener : MonoBehaviour
{
    [SerializeField] private ParamsEventInvoker _paramsEventInvoker;
    [SerializeField] private TextMeshProUGUI _buttonText;

    private void Awake()
    {
        _paramsEventInvoker
          .ParamsR3Event
          .Prepend(10)
          .Subscribe(counter => _buttonText.text = counter.ToString())
          .AddTo(this);
    }
}
