using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerView _towerView;
    [SerializeField] private TowerStateType _towerStateType;
    [SerializeField] private int _level;
    public int MAX_LEVEL => 3;

    public int Level { get => _level; }
    public TowerStateType TowerStateType { get => _towerStateType; }
    private TowerState _towerState;


    private void Start()
    {
        SetState(_towerStateType);
        UpdateView();
    }

    public void UpdateView()
    {
        _towerView.UpdateView(_towerStateType, _level);
    }

    /// <summary>
    /// При клике решаем какие кнопочки создавать и что на них делать
    /// Создаём дату и отправляем попапу, он на их основе активирует кнопочки
    /// </summary>
    public List<TowerActionData> GetActionData()
    {
        return _towerState.GetActionData();
    }

    public void Upgrade()
    {
        _towerState.Upgrade();
    }

    public void Repair()
    {
        _towerState.Repair();
    }

    public void Salvage()
    {
        _towerState.Salvage();
    }

    public void SetLevel(int level)
    {
        if (level < 0 || level > MAX_LEVEL)
        {
            Debug.LogError("Something wrong! Level can't be " + level);
            return;
        }

        _level = level;
    }

    public void AddLevel()
    {
        if (_level < MAX_LEVEL)
        {
            _level++;
        }
        else
        {
            Debug.LogError("Level is already MAX");
        }
    }

    public void SetState(TowerStateType towerStateType)
    {
        TowerState newState;
        switch (towerStateType)
        {
            case TowerStateType.NotConstructed:
                newState = new NotConstructedTowerState();
                break;
            case TowerStateType.Active:
                newState = new ActiveTowerState();
                break;
            case TowerStateType.Broken:
                newState = new BrokenTowerState();
                break;
            default:
                newState = null;
                Debug.LogError("No create method for type " + towerStateType);
                break;
        }
        _towerState = newState;
    }
}
