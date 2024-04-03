using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private float _timeBetweenTurns;
    private List<TurnType> _playerTurns = new List<TurnType>();

    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerShapeChanger _playerShapeChanger;

    public event Action<TurnType> TurnAdded;
    public event Action TurnFinished;
    public event Action TurnCanceled;

    public event Action SequenceStarted;
    public event Action SequenceFailed;
    public event Action SequenceFinished;

    public void AddTurn(TurnType turnType)
    {
        _playerTurns.Add(turnType);
        TurnAdded?.Invoke(turnType);
    }

    public void Undo()
    {
        if (_playerTurns.Count > 0)
        {
            _playerTurns.RemoveAt(_playerTurns.Count - 1);
            TurnCanceled?.Invoke();
        }
    }

    public void Play()
    {
        StartCoroutine(PlayTurnsCoroutine());
    }

    private IEnumerator PlayTurnsCoroutine()
    {
        foreach (var turn in _playerTurns)
        {
            bool success = PlayTurn(turn);
            if (!success)
            {
                SequenceFailed?.Invoke();
                _playerTurns.Clear();
                yield break;
            }
            TurnFinished?.Invoke();
            yield return new WaitForSeconds(_timeBetweenTurns);
        }
        SequenceFinished?.Invoke();
        _playerTurns.Clear();
    }

    private bool PlayTurn(TurnType turnType)
    {
        switch (turnType)
        {
            case TurnType.MoveUp:
                return _playerMover.Move(-1, 0);
            case TurnType.MoveDown:
                return _playerMover.Move(1, 0);
            case TurnType.MoveLeft:
                return _playerMover.Move(0, -1);
            case TurnType.MoveRight:
                return _playerMover.Move(0, 1);
            case TurnType.ShapeToCube:
                _playerShapeChanger.SetShape(PlayerShape.Cube);
                return true;
            case TurnType.ShapeToSphere:
                _playerShapeChanger.SetShape(PlayerShape.Sphere);
                return true;
            default:
                Debug.LogError("Unknown turn type " + turnType);
                return false;
        }
    }
}