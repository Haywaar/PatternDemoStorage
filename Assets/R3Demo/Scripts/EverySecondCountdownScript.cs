using System;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EverySecondCountdownScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private double _timeLeft = 10;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Awake()
    {
        _titleText.text = "Считает с 10 до 0 а затем останавливается";

        _button.onClick.AddListener(() => StartTimer());
    }

    private void StartTimer()
    {
        _buttonText.text = _timeLeft.ToString();

        Observable
            .Interval(TimeSpan.FromSeconds(1.0f))
            .Subscribe(_ => MinusTick())
            .AddTo(_disposable);
    }

    private void MinusTick()
    {
        _timeLeft -= 1.0f;
        _buttonText.text = _timeLeft.ToString();

        if (_timeLeft < 0)
        {
            _buttonText.text = "Остановлен";

            _disposable.Dispose();
        }
    }

    private void OnDestroy()
    {
        _disposable.Dispose();
    }
}
