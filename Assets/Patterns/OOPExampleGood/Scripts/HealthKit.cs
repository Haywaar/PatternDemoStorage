using UnityEngine;

public class HealthKit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.AddHealth(1);
            Destroy(gameObject);
        }
    }
}
