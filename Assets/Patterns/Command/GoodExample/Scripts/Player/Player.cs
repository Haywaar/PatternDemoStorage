using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2Int _playerPos;
    private PlayerShape _playerShape = PlayerShape.Cube;

    public Vector2Int Pos { get => _playerPos; }
    public PlayerShape Shape { get => _playerShape; }

    public void SetPos(Vector2Int newPos)
    {
        _playerPos = newPos;
    }

    public void SetShape(PlayerShape playerShape)
    {
        _playerShape = playerShape;
    }
}