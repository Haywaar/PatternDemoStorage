using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPercentBonusInteractable : Interactable
{
    // 0.5f = 50%
    [SerializeField] private float _percentBonus = 0.5f;
    protected override void Interact(PlayerDamageController playerDamageController)
    {
        playerDamageController.AddPercentBonusDamage(_percentBonus);
    }
}
