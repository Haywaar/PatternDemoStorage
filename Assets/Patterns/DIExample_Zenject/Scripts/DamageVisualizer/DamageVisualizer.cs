using UnityEngine;
using UnityEngine.UI;

namespace Patterns.DIExample_Zenject.Scripts
{
    public abstract class DamageVisualizer : MonoBehaviour
    {
        [SerializeField] private Text _textPrefab;
        [SerializeField] private RectTransform _spawnRect;
        [SerializeField] private RectTransform _textRoot;
        public void Visualize(string textVal, Transform spawnPosition)
        {
            var go = GameObject.Instantiate(_textPrefab, _spawnRect.position, Quaternion.identity, _textRoot);
            go.text = textVal;
            go.transform.position = spawnPosition.position;
            Fly(go.gameObject);
        }

        /// <summary>
        /// Логика того, как именно полетит текст с уроном
        /// </summary>
        public abstract void Fly(GameObject flyingText);
    }
}