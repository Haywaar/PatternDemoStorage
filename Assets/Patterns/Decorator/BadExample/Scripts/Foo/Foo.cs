using System.Collections.Generic;
using UnityEngine;

public class Foo
{
    
}

public abstract class ShipSlot
{
    public abstract void Execute();
}

public class Turret : ShipSlot
{
    private float damage;
    public override void Execute()
    {
        Debug.Log("Бахает по супостатам");
    }
}

public class ShieldGenerator : ShipSlot
{
    private float regenValue;
    private float regenCooldown;

    public override void Execute()
    {
        Debug.Log("Регенерирует щит");
    }
}

public class Ship
{
    private List<ShipSlot> Slots;

    public void AddSlot(ShipSlot slot)
    {
        Slots.Add(slot);
    }

    public void UseAll()
    {
        foreach (var slot in Slots)
        {
            slot.Execute();
        }
    }
}
