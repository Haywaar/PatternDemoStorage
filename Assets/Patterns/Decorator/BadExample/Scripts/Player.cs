using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 1.0f;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private GameObject _projectilePrefab;


    [SerializeField] private PlayerDamageController _playerDamageController;

    public float MovementSpeed { get => _movementSpeed; }

    public void Shoot()
    {
        var projectile = GameObject.Instantiate(_projectilePrefab, transform);

        var tween = projectile.transform.DOMove(_enemy.transform.position, 0.3f);
        tween.SetEase(Ease.Linear);
        tween.onComplete += () =>
        {
            _enemy.OnTakenDamage(_playerDamageController.GetDamageValue());
            Destroy(projectile.gameObject);
        };
    }
}