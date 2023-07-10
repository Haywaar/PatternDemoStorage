using UnityEngine;
using UnityEngine.UI;

public class Warrior : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Text _priceText;
    private int _id;

    public void Init(int id)
    {
        _id = id;
        DisplayText();
    }

    public void Attack()
    {
        // Melee Attack
    }

    public int GetPrice()
    {
        if (IsThird())
        {
            return 15;
        }

        return 10;
    }

    private bool IsThird()
    {
        return (_id + 1) % 3 == 0;
    }

    private void DisplayText()
    {
        _priceText.text = GetPrice().ToString();
        _priceText.color = IsThird() ? Color.yellow : Color.white;
    }
}