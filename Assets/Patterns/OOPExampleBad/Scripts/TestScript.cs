using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TestScript : MonoBehaviour
{
    [SerializeField] private Warrior _warriorPrefab;
    [SerializeField] private Mage _magePrefab;
    [SerializeField] private Ranger _rangerPrefab;

    [SerializeField] private RectTransform _unitGrid;

    private List<Warrior> _warriors = new();
    private List<Mage> _mages = new();
    private List<Ranger> _rangers = new();

    [SerializeField] private Button _generateUnits;
    [SerializeField] private Text _totalGoldText;

    private void GenerateUnits()
    {
        _warriors.Clear();
        _mages.Clear();
        _rangers.Clear();
        
        int id = 0;
        int warriorCount = Random.Range(0, 5);
        for (int i = 0; i < warriorCount; i++)
        {
            var warrior = Instantiate(_warriorPrefab, _unitGrid);
            warrior.Init(id);
            id++;
            _warriors.Add(warrior);
        }

        int mageCount = Random.Range(0, 5);
        for (int i = 0; i < mageCount; i++)
        {
            var mage = Instantiate(_magePrefab, _unitGrid);
            mage.Init(id);
            id++;
            _mages.Add(mage);
        }

        int rangerCount = Random.Range(0, 5);
        for (int i = 0; i < rangerCount; i++)
        {
            var ranger = Instantiate(_rangerPrefab, _unitGrid);
            ranger.Init(id);
            id++;
            _rangers.Add(ranger);
        }
    }

    private void CalculateTotalPrice()
    {
        int price = 0;

        foreach (var warrior in _warriors)
        {
            price += warrior.GetPrice();
        }

        foreach (var mage in _mages)
        {
            price += mage.GetPrice();
        }

        foreach (var ranger in _rangers)
        {
            price += ranger.GetPrice();
        }

        _totalGoldText.text = "Total price: " + price;
    }

    private void Start()
    {
        _generateUnits.onClick.AddListener((() =>
        {
            // Чистим грид
            foreach (Transform child in _unitGrid.transform)
            {
                Destroy(child.gameObject);
            }

            GenerateUnits();
            CalculateTotalPrice();
        }));
    }
}