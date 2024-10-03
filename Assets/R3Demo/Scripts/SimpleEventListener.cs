using UnityEngine;
using R3;

public class SimpleEventListener : MonoBehaviour
{
    [SerializeField] private SimpleEventInvoker _simpleEventInvoker;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Awake()
    {
        _simpleEventInvoker.OnSimpleEvent += OnSimpleEvent;

        _simpleEventInvoker
        .OnSimpleR3Event
        .Subscribe(_ => OnSimpleR3Event())
        .AddTo(_disposable);
    }

    private void OnSimpleEvent()
    {
        Debug.Log("SimpleEvent Handled");
    }

    private void OnSimpleR3Event()
    {
       Debug.Log("SimpleR3Event Handled");
    }

    private void OnDestroy()
    {
        _disposable.Dispose();
    }
}
