using System;
using R3;
using UnityEngine;
using UnityEngine.UI;

public class SimpleEventInvoker : MonoBehaviour
{
    [SerializeField] private Button _button;

    public event Action OnSimpleEvent;

    public readonly Subject<Unit> OnSimpleR3Event = new();


    private void Awake()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        OnSimpleEvent?.Invoke();

        OnSimpleR3Event.OnNext(Unit.Default);
    }
}
