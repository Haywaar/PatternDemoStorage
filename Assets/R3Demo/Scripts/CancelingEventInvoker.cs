using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CancelingEventInvoker : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _buttonText;

    public readonly Subject<int> CancelingR3Event = new();
    private int _counter = 0;

    private void Awake()
    {
        _button.onClick.AddListener(OnButtonClicked);
        _buttonText.text = _counter.ToString();
    }

    private void OnButtonClicked()
    {
        _counter++;
        _buttonText.text = _counter.ToString();
        CancelingR3Event.OnNext(_counter);

        if(_counter >= 10)
        {
            CancelingR3Event.OnCompleted();
        }
    }
}
