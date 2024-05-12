using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private DamageVisualizer _damageVisualizer;

    private Tween _tween;

    private Vector3 _startPos;

    private void Awake()
    {
        _startPos = transform.position;
    }
    
    public void OnTakenDamage(float damage)
    {
        _damageVisualizer.Visualize(damage.ToString(), transform);
        
        if(_tween != null)
        {
            _tween.Kill();
        }
        _tween = transform.DOShakePosition(0.5f, 3f, 10, 1);
        _tween.onComplete += () => transform.position = _startPos;
    }

    
}