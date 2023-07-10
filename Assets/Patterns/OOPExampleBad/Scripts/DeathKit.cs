using UnityEngine;

public class DeathKit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            if (player.health > 0)
            {
                player.health -= 1;
            }

            if (player.health == 0)
            {
                Debug.Log("You Dead!");
            }

            Destroy(gameObject);
        }
    }
}
