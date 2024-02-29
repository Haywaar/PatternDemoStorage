using System.Collections.Generic;

public class BrokenTowerState : TowerState
{
    public override List<TowerActionData> GetActionData()
    {
        return new List<TowerActionData>()
        {
            new TowerActionData(TowerActionType.Repair, Repair),
            new TowerActionData(TowerActionType.Salvage, Salvage)
        };
    }

    public override void Repair()
    {
        _tower.SetState(TowerStateType.Active);
    }

    public override void Salvage()
    {
        _tower.SetLevel(0);
        _tower.SetState(TowerStateType.NotConstructed);
    }

    public override void Upgrade()
    {
       // Ничего не делаем - улучшение невозможно
    }
}