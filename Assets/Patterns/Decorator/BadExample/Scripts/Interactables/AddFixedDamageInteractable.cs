using UnityEngine;

public class AddFixedDamageInteractable : Interactable
{
    [SerializeField] private float _addDamage = 10f;
    protected override void Interact(PlayerDamageController playerDamageController)
    {
        playerDamageController.AddFixedDamage(_addDamage);
    }
}