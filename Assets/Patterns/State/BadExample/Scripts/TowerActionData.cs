using UnityEngine.Events;

public class TowerActionData
{
    public readonly TowerActionType TowerActionType;
    public readonly UnityAction Callback;

    public TowerActionData(TowerActionType towerActionType, UnityAction callback)
    {
        TowerActionType = towerActionType;
        Callback = callback;
    }
}