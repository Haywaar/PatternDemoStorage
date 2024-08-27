using UnityEngine;
using R3;
using TMPro;

public class CancelingEventListener : MonoBehaviour
{
    [SerializeField] private CancelingEventInvoker _cancelingEventInvoker;
    [SerializeField] private TextMeshProUGUI _buttonText;

    private void Awake()
    {
        _cancelingEventInvoker
        .CancelingR3Event
        .Subscribe(OnCancelingR3Event)
        .AddTo(this);
    }

    private void OnCancelingR3Event(int counter)
    {
        _buttonText.text = counter.ToString();
    }
}
