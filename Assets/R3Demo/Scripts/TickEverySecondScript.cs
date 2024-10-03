using System;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TickEverySecondScript : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _buttonText;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private int _ticks = 0;

    private void Awake()
    {
        _button.onClick.AddListener(() => StartTimer());
    }

    private void StartTimer()
    {
        Observable
            .Interval(TimeSpan.FromSeconds(1.0f))
            .Subscribe(_ => AddTick())
            .AddTo(_disposable);
    }

    private void AddTick()
    {
        _ticks++;
        _buttonText.text = _ticks.ToString();
    }

    private void OnDestroy()
    {
        _disposable.Dispose();
    }
}
