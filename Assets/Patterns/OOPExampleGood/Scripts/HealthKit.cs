using UnityEngine;

public class HealthKit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            int value = 1;




            player.AddHealth(value);



            Destroy(gameObject);
        }
    }
}

public abstract class Command
{
    protected Player player;
    protected int value;
    public abstract void Execute();
}

public class AddHealthCommand : Command
{
    public override void Execute()
    {
        player.AddHealth(value);
    }
}

