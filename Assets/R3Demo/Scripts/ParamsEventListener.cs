using TMPro;
using UnityEngine;
using R3;

public class ParamsEventListener : MonoBehaviour
{
    [SerializeField] private ParamsEventInvoker _paramsEventInvoker;
    [SerializeField] private TextMeshProUGUI _buttonText;

    private void Awake()
    {
        _paramsEventInvoker.ParamsR3Event
          .Where(counter => counter % 2 == 0)
          .Subscribe(counter => _buttonText.text = counter.ToString())
          .AddTo(this);

          _buttonText.text = "0";
    }
}
