using TMPro;
using UnityEngine;
using R3;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _healthText;

    private void Start()
    {
        _player.Health
        .Subscribe(RedrawHealth)
        .AddTo(this);

        _player.IsDead
        .Subscribe(RedrawIsDead)
        .AddTo(this);
    }

    private void RedrawHealth(int health)
    {
        _healthText.text = "Health: " + health.ToString();
    }

    private void RedrawIsDead(bool isDead)
    {
        if (isDead)
        {
           Debug.LogWarningFormat("Dead");
        }
    }
}
