using UnityEngine;

namespace Patterns.DIExample.Scripts.PlayerInput
{
    public class KeyboardInputHandler : InputHandler
    {
        public override void Handle()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                var enemy = GameObject.FindObjectOfType<Enemy>();
                if (enemy != null)
                {
                    SendEnemyClicked(enemy);
                }
            }
        }
    }
}