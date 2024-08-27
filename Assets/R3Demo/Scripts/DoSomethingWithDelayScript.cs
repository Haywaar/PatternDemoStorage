using System;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using R3.Collections;

public class DoSomethingWithDelayScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private float _delay = 3.0f;

    private CompositeDisposable _disposable = new CompositeDisposable();


    private void Awake()
    {
        _titleText.text = string.Format("Перерисует текст на кнопке через {0} секунд", _delay);

        _button.onClick.AddListener(() =>
        {
            DoSomethingWithDelay();
        });

    }

    private void DoSomethingWithDelay()
    {
        _buttonText.text = "Выполняется...";

        Observable
        .Timer(TimeSpan.FromSeconds(_delay))
        .Subscribe(_ => DoSomething())
        .AddTo(_disposable);
    }

    private void DoSomething()
    {
        _buttonText.text = "Готово";
    }

    private void OnDestroy()
    {
        _disposable.Dispose();
    }
}
