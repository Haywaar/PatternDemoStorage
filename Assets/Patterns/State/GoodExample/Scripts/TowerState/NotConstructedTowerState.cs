using System.Collections.Generic;
using UnityEngine;

public class NotConstructedTowerState : TowerState
{
    public override List<TowerActionData> GetActionData()
    {
        var actionData = new List<TowerActionData>
        {
            new TowerActionData(TowerActionType.Upgrade, Upgrade)
        };
        return actionData;
    }

    public override void Repair()
    {
        // Ничего не делаем - починка невозможна
    }

    public override void Salvage()
    {
       // Ничего не делаем - разбор невозможен
    }

    public override void Upgrade()
    {
        _tower.SetLevel(1);
        _tower.SetState(TowerStateType.Active);
    }
}