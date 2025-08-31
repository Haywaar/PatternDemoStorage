using UnityEngine;
using UnityEngine.UI;

namespace Patterns.OOPExampleGood.Scripts.EncapsulationDemo
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Text _healthText;

        private ReadonlyPlayerV1 _player;

        private void Redraw()
        {
            var health = _player.Health;
            _slider.value = (float) (health / _player.MaxHealth);
            _healthText.text = "Health: " + health;
            

        }
    }
}