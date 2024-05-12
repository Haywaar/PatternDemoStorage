using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected abstract void Interact(PlayerDamageController playerDamageController);

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            var damageController = col.gameObject.GetComponent<PlayerDamageController>();
            Interact(damageController);
            Dispose();
        }
    }

    private void Dispose()
    {
        Destroy(this.gameObject);
    }
}


