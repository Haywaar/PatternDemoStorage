using UnityEngine;
using UnityEngine.UI;
using R3;
using TMPro;

public class ReplaySubjectEventListener : MonoBehaviour
{
    [SerializeField] private ReplaySubjectEventInvoker _replaySubjectInvoker;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private TextMeshProUGUI _statusText;
    [SerializeField] private Button _subscribeButton;


    private void Awake()
    {
        _subscribeButton.onClick.AddListener(Subscribe);
    }

    private void Subscribe()
    {
        _statusText.text = "Subscribed";
        _replaySubjectInvoker.ReplayR3Event
                  .Subscribe(x => OnReplayR3Event(x))
                  .AddTo(this);
    }

    private void OnReplayR3Event(int x)
    {
        Debug.LogWarningFormat($"Replay {x}!");
        _buttonText.text = x.ToString();
    }
}
