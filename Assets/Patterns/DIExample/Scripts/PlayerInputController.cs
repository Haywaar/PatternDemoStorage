using System;
using Patterns.DIExample.Scripts.PlayerInput;
using UnityEngine;

namespace Patterns.DIExample.Scripts
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private float _attackCooldown = 1.0f;
        private InputHandler _inputHandler;

        public event Action<Enemy> EnemyAttackRequest;
        private DateTime _previousAttackTime;

        public void Construct(InputHandler inputHandler)
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