using TMPro;
using UnityEngine;
using R3;
using System;

public class MergeEventListener : MonoBehaviour
{
    [SerializeField] private ParamsEventInvoker _paramsEventInvoker_1;
    [SerializeField] private ParamsEventInvoker _paramsEventInvoker_2;
    [SerializeField] private TextMeshProUGUI _buttonText;


    private void Awake()
    {
        _paramsEventInvoker_1.ParamsR3Event
        .Merge(_paramsEventInvoker_2.ParamsR3Event)
        .Subscribe(x => DisplayText(x))
        .AddTo(this);
    }

    private void DisplayText(int x)
    {
        _buttonText.text = x.ToString();
    }
}
