using System.Collections.Generic;

public class ActiveTowerState : TowerState
{
    public override List<TowerActionData> GetActionData()
    {
        var actionData = new List<TowerActionData>();
        if (_tower.Level < _tower.MAX_LEVEL)
        {
            actionData.Add(new TowerActionData(TowerActionType.Upgrade, Upgrade));
        }
        actionData.Add(new TowerActionData(TowerActionType.Salvage, Salvage));
        return actionData;
    }

    public override void Repair()
    {
        //Ничего не делаем - в починке нет нужды
    }

    public override void Salvage()
    {
        _tower.SetLevel(0);
        _tower.SetState(TowerStateType.NotConstructed);
    }

    public override void Upgrade()
    {
        if (_tower.Level < _tower.MAX_LEVEL)
        {
            _tower.AddLevel();
        }
    }
}