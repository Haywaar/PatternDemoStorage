using System;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TickEveryFrameScript : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _buttonText;

    private double _passedTime = 0;

    private void Awake()
    {
        _button.onClick.AddListener(() => StartTimer());
    }

    private void StartTimer()
    {
        Observable
            .EveryUpdate()
            .Subscribe(_ => AddTick())
            .AddTo(this);
    }

    private void AddTick()
    {
        _passedTime += Time.deltaTime;
        _buttonText.text = _passedTime.ToString();
    }
}
