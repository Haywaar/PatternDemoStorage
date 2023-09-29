using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Patterns.DIExample_Zenject.Scripts.PlayerInput
{
    public class MouseInputHandler : InputHandler
    {
        public override void Handle()
        {
            var touchPos = Input.mousePosition;
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                var pointerEventData = new PointerEventData(EventSystem.current) { position = touchPos };
                var raycastResults = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerEventData, raycastResults);

                if (raycastResults.Count > 0)
                {
                    foreach (var result in raycastResults)
                    {
                        if (result.gameObject.tag.Equals("Enemy"))
                        {
                            var enemy = result.gameObject.GetComponent<Enemy>();
                            if (enemy != null)
                            {
                                SendEnemyClicked(enemy);
                            }

                            break;
                        }
                    }
                }
            }
        }
    }
}