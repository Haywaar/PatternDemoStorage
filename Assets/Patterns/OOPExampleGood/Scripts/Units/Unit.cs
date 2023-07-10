using UnityEngine;
using UnityEngine.UI;

namespace Patterns.IncapsulationExampleGood.Scripts.Units
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] protected int _health;
        [SerializeField] private Text _priceText;
        protected int _id;

        public void Init(int id)
        {
            _id = id;
            DisplayText();
        }

        protected bool IsThird()
        {
            return ((_id + 1) % 3 == 0);
        }

        protected void DisplayText()
        {
            _priceText.text = GetPrice().ToString();
            _priceText.color = IsThird() ? Color.yellow : Color.white;
        }

        public abstract int GetPrice();
    }
}