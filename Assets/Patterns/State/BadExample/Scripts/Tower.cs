using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerView _towerView;
    [SerializeField] private TowerStateType _towerStateType;
    [SerializeField] private int _level;
    private const int MAX_LEVEL = 3;

    public int Level { get => _level; }
    public TowerStateType TowerStateType { get => _towerStateType; }

    private void Start()
    {
        _towerView.UpdateView(_towerStateType, _level);
    }

    /// <summary>
    /// При клике решаем какие кнопочки создавать и что на них делать
    /// Создаём дату и отправляем попапу, он на их основе активирует кнопочки
    /// </summary>
    public List<TowerActionData> GetActionData()
    {
        var actionData = new List<TowerActionData>();

        switch (_towerStateType)
        {
            case TowerStateType.NotConstructed:
                actionData.Add(new TowerActionData(TowerActionType.Upgrade, Upgrade));
                break;
            case TowerStateType.Active:
                if (_level < MAX_LEVEL)
                {
                    actionData.Add(new TowerActionData(TowerActionType.Upgrade, Upgrade));
                }
                actionData.Add(new TowerActionData(TowerActionType.Salvage, Salvage));
                break;
            case TowerStateType.Broken:
                actionData.Add(new TowerActionData(TowerActionType.Repair, Repair));
                actionData.Add(new TowerActionData(TowerActionType.Salvage, Salvage));
                break;
        }

        return actionData;
    }

    private void Upgrade()
    {
        switch (_towerStateType)
        {
            case TowerStateType.NotConstructed:
                _level = 1;
                _towerStateType = TowerStateType.Active;
                break;
            case TowerStateType.Active:
                if (_level < MAX_LEVEL)
                {
                    _level++;
                }
                break;
            case TowerStateType.Broken:
                // Ничего не делаем - апгрейд невозможен
                break;
        }
        _towerView.UpdateView(_towerStateType, _level);
    }

    private void Repair()
    {
        switch (_towerStateType)
        {
            case TowerStateType.NotConstructed:
                // Ничего не делаем - починка невозможна
                break;
            case TowerStateType.Active:
                // Ничего не делаем - починка невозможна
                break;
            case TowerStateType.Broken:
                _towerStateType = TowerStateType.Active;
                break;
        }
        _towerView.UpdateView(_towerStateType, _level);
    }

    private void Salvage()
    {
        switch (_towerStateType)
        {
            case TowerStateType.NotConstructed:
                // Ничего не делаем - разбор невозможен
                break;
            case TowerStateType.Active:
                _towerStateType = TowerStateType.NotConstructed;
                break;
            case TowerStateType.Broken:
                _towerStateType = TowerStateType.NotConstructed;
                break;
        }
        _towerView.UpdateView(_towerStateType, _level);
    }
}
