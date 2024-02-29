using System.Collections.Generic;
using UnityEngine;

//Меняет го башни в зависимости от уровня и состояния
public class TowerView : MonoBehaviour
{
    [SerializeField] private GameObject _broken;
    [SerializeField] private GameObject _notConstructed;
    [SerializeField] private List<GameObject> _towerLevels;

    public void UpdateView(TowerStateType towerState, int towerLevel)
    {
        HideAll();
        switch (towerState)
        {
            case TowerStateType.NotConstructed:
            _notConstructed.gameObject.SetActive(true);
            break;
             case TowerStateType.Broken:
            _broken.gameObject.SetActive(true);
            break;
            case TowerStateType.Active:
            _towerLevels[towerLevel - 1].gameObject.SetActive(true);
            break;
        }
    }

    private void HideAll()
    {
        _broken.gameObject.SetActive(false);
        _notConstructed.gameObject.SetActive(false);
        foreach(var tower in _towerLevels)
        {
            tower.gameObject.SetActive(false);
        }
    }


}