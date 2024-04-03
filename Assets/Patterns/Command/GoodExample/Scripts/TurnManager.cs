using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Invoker
public class TurnManager : MonoBehaviour
{
    [SerializeField] private float _timeBetweenTurns;
    private List<Command> _playerCommands = new List<Command>();

    public event Action<Command> TurnAdded;
    public event Action TurnFinished;
    public event Action TurnCanceled;

    public event Action SequenceStarted;
    public event Action SequenceFailed;
    public event Action SequenceFinished;

    public void AddTurn(Command command)
    {
        _playerCommands.Add(command);
        TurnAdded?.Invoke(command);
    }

    public void Undo()
    {
        if (_playerCommands.Count > 0)
        {
            _playerCommands.RemoveAt(_playerCommands.Count - 1);
            TurnCanceled?.Invoke();
        }
    }

    public void Play()
    {
        StartCoroutine(PlayTurnsCoroutine());
    }

    private IEnumerator PlayTurnsCoroutine()
    {
        foreach (var command in _playerCommands)
        {
            bool success = command.CanBeExecuted();
            if (!success)
            {
                SequenceFailed?.Invoke();
                _playerCommands.Clear();
                yield break;
            }
            
            command.Execute();

            TurnFinished?.Invoke();
            yield return new WaitForSeconds(_timeBetweenTurns);
        }
        SequenceFinished?.Invoke();
        _playerCommands.Clear();
    }
}