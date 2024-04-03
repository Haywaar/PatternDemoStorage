using System;
using System.Collections.Generic;
using UnityEngine;

public class UI_TurnsQueuePanel : MonoBehaviour
{
    [SerializeField] private TurnManager _turnManager;
    [SerializeField] private RectTransform _queueRoot;
    [SerializeField] private UI_TurnSlot _turnSlot;

    private List<UI_TurnSlot> _slotsQueue = new List<UI_TurnSlot>();

    private void Awake()
    {
        _turnManager.TurnAdded += OnTurnAdded;
        _turnManager.TurnCanceled += OnTurnCanceled;
        _turnManager.TurnFinished += OnTurnFinished;

        _turnManager.SequenceFailed += OnSequenceFailed;
    }

    private void OnTurnAdded(Command command)
    {
        var slot = GameObject.Instantiate(_turnSlot, _queueRoot);
        slot.Init(command);
        _slotsQueue.Add(slot);
    }

    private void OnTurnCanceled()
    {
        if (_slotsQueue.Count > 0)
        {
            var slot = _slotsQueue[_slotsQueue.Count - 1];
            Destroy(slot.gameObject);
            _slotsQueue.RemoveAt(_slotsQueue.Count - 1);
        }
    }
    private void OnTurnFinished()
    {
        if (_slotsQueue.Count > 0)
        {
            var slot = _slotsQueue[0];
            Destroy(slot.gameObject);
            _slotsQueue.RemoveAt(0);
        }
    }

    private void OnSequenceFailed()
    {
        if (_slotsQueue.Count > 0)
        {
            foreach (var slot in _slotsQueue)
            {
                Destroy(slot.gameObject);
            }
            _slotsQueue.Clear();
        }
    }

}