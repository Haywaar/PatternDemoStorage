using UnityEngine;

// Client
public class CommandFabric : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerShapeChanger _playerShapeChanger;

    public Command CreateMoveCommand(MoveDirection direction, int distance)
    {
        return new MoveCommand(direction, distance, _playerMover);
    }

    public Command CreateMoveLeftCommand()
    {
        return CreateMoveCommand(MoveDirection.Left, 1);
    }

    public Command CreateMoveRightCommand()
    {
        return CreateMoveCommand(MoveDirection.Right, 1);
    }

    public Command CreateChangeShapeCommand(PlayerShape playerShape)
    {
        return new ChangeShapeCommand(_playerShapeChanger, playerShape);
    }
}