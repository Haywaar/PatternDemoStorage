using UnityEngine;
using R3;
using UnityEngine.UI;
using System;

public class SelectEventListener : MonoBehaviour
{
    [SerializeField] private ParamsEventInvoker _paramsEventInvoker;
    [SerializeField] private Text _buttonText;

    private void Awake()
    {
        _paramsEventInvoker.ParamsR3Event
        .Select(counter => counter + 40)
        .Select(counter => (char)counter)
        .Subscribe(DrawSymbol)
        .AddTo(this);

        _buttonText.text = "0";
    }

    private void DrawSymbol(char counter)
    {
       _buttonText.text = counter.ToString();
    }
}
