using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private TurnManager _turnManager;
    [SerializeField] private PlaygroundLoader _playgroundLoader;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerShapeChanger _playerShapeChanger;


    private void Awake()
    {
        _turnManager.SequenceFailed += OnSequenceFailed;
        _turnManager.SequenceFinished += OnSequenceFinished;
    }

    private void OnSequenceFinished()
    {
        var field = _playgroundLoader.CellField;
        if (field.GetExitPoint().Equals(_player.Pos))
        {
            _playgroundLoader.LoadNextLevel();
        }
        else
        {
            Debug.LogWarning("Lose!");
        }
        _playerMover.Reset();
        _playerShapeChanger.Reset();
    }

    private void OnSequenceFailed()
    {
        _playerMover.Reset();
        _playerShapeChanger.Reset();
    }
}