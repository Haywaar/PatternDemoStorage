using UnityEngine;

public class HealthKit : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            var player = col.gameObject.GetComponent<Player>();
            player.AddHealth(1);
            Destroy(this.gameObject);
        }
    }
}
