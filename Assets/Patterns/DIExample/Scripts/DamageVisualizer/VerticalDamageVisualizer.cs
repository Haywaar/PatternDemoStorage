using DG.Tweening;
using UnityEngine;

namespace Patterns.DIExample.Scripts.Services.DamageVisualizer
{
    public class VerticalDamageVisualizer : DamageVisualizer
    {
        public override void Fly(GameObject flyingText)
        {
            var endPoint = flyingText.transform.position + new Vector3(0, 1000, 0);
            var tween = flyingText.transform.DOMove(
                endPoint, 3.0f);

            tween.onComplete += () => Destroy(flyingText.gameObject);
        }
    }
}