using UnityEngine;

public class MoveCommand : Command
{
    public readonly MoveDirection Direction;
    public readonly int Distance;
    
    // Receiver
    private PlayerMover _playerMover;

    public MoveCommand(MoveDirection direction, int distance, PlayerMover playerMover)
    {
        Direction = direction;
        Distance = distance;
        _playerMover = playerMover;
    }

    public override bool CanBeExecuted()
    {
        var dir = GetVectorDirection() * Distance;
        return _playerMover.CanBeMoved(dir.x, dir.y);
    }

    public override void Execute()
    {
        var dir = GetVectorDirection() * Distance;
        _playerMover.Move(dir.x, dir.y);
    }

    public override TurnType GetTurnType()
    {
        return TurnType.Move;
    }

    private Vector2Int GetVectorDirection()
    {
        Vector2Int vector = new Vector2Int();
        switch (Direction)
        {
            case MoveDirection.Up:
                vector = new Vector2Int(-1, 0);
                break;
            case MoveDirection.Down:
                vector = new Vector2Int(1, 0);
                break;
            case MoveDirection.Left:
                vector = new Vector2Int(0, -1);
                break;
            case MoveDirection.Right:
                vector = new Vector2Int(0, 1);
                break;
        }
        return vector;
    }
}