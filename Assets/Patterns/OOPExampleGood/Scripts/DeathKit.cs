using UnityEngine;

public class DeathKit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.RemoveHealth(1);
            Destroy(gameObject);
        }
    }
}
