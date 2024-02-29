using System.Collections.Generic;

public abstract class TowerState
{
    protected Tower _tower;

    public abstract List<TowerActionData> GetActionData();
    public abstract void Upgrade();
    public abstract void Repair();
    public abstract void Salvage();
}
