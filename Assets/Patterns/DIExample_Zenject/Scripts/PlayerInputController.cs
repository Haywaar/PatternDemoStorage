using System;
using Patterns.DIExample_Zenject.Scripts.PlayerInput;
using UnityEngine;
using Zenject;

namespace Patterns.DIExample_Zenject.Scripts
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private float _attackCooldown = 1.0f;
        private InputHandler _inputHandler;

        public event Action<Enemy> EnemyAttackRequest;
        private DateTime _previousAttackTime;

        [Inject]
        private void Init(InputHandler inputHandler)
        {
            _inputHandler = inputHandler;
            _inputHandler.EnemyClicked += OnEnemyClicked;
        }

        private void OnEnemyClicked(Enemy enemy)
        {
            if (_previousAttackTime.AddSeconds(_attackCooldown) < DateTime.Now)
            {
                _previousAttackTime = DateTime.Now;
                EnemyAttackRequest?.Invoke(enemy);
            }
            else
            {
                Debug.Log("Погоди, Петрович, не спеши!");
            }
        }

        private void Update()
        {
            _inputHandler.Handle();
        }
    }
}