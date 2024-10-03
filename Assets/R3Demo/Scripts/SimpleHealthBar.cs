using UnityEngine;

public class SimpleHealthBar : MonoBehaviour
{
    public SimplePlayer _player;

    private void Awake()
    {
        _player.OnHealthChanged += DrawHealth;
    }

    private void DrawHealth(int health)
    {
        // Draw health
    }
}

