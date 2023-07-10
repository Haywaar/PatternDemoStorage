using UnityEngine;

public class HealthKit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            if (player.health < player.maxHealth)
            {
                player.health += 1;
            }

            Destroy(gameObject);
        }
    }
}
