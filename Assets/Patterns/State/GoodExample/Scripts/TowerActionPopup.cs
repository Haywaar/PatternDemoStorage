using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerActionPopup : MonoBehaviour
{
    [SerializeField] private RectTransform _root;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Button _repairButton;
    [SerializeField] private Button _salvageButton;

    public void ShowPopup(List<TowerActionData> towerData)
    {
        Hide();

        _root.transform.position = Input.mousePosition;
        _root.gameObject.SetActive(true);

        foreach (var actionData in towerData)
        {
           var button = GetButtonByType(actionData.TowerActionType);
           button.gameObject.SetActive(true);
           button.onClick.RemoveAllListeners();
           button.onClick.AddListener(actionData.Callback);
           button.onClick.AddListener(Hide);
        }
    }

    public void Hide()
    {
        _root.gameObject.SetActive(false);
        _upgradeButton.gameObject.SetActive(false);
        _repairButton.gameObject.SetActive(false);
        _salvageButton.gameObject.SetActive(false);
    }

    private Button GetButtonByType(TowerActionType towerActionType)
    {
        switch (towerActionType)
        {
            case TowerActionType.Upgrade:
                return _upgradeButton;
            case TowerActionType.Repair:
                return _repairButton;
            case TowerActionType.Salvage:
                return _salvageButton;
            default:
                Debug.LogError("Not all enums for TowerActionPopup covered! Unknown type " + towerActionType);
                return null;
        }
    }
}