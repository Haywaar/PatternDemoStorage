using UnityEngine;

public class DamageMine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            var player = col.gameObject.GetComponent<Player>();
            player.TakeDamage(1);
            Destroy(this.gameObject);
        }
    }
}
