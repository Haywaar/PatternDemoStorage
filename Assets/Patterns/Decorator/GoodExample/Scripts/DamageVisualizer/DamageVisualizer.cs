using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class DamageVisualizer : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textPrefab;
    [SerializeField] private Transform _textRoot;

    public void Visualize(string textVal, Transform targetTransform)
    {
        var go = GameObject.Instantiate(_textPrefab, targetTransform.position, Quaternion.identity, _textRoot);
        go.text = textVal;
        //go.transform.position = spawnPosition.position;
        Fly(go.gameObject);
    }

    /// <summary>
    /// Логика того, как именно полетит текст с уроном
    /// </summary>
    private void Fly(GameObject flyingText)
    {
        var endPoint = flyingText.transform.position + new Vector3(0, 10, 0);
        var tween = flyingText.transform.DOMove(
            endPoint, 3.0f);

        tween.onComplete += () => Destroy(flyingText.gameObject);
    }
}