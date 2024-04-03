using UnityEngine;
using UnityEngine.UI;

public class UI_TurnSlot : MonoBehaviour
{
    [SerializeField] private Image _image;

    // Can move in config or another script in future
    [SerializeField] private Sprite _moveSprite;
    [SerializeField] private Sprite _cubeSprite;
    [SerializeField] private Sprite _sphereSprite;

    public void Init(Command command)
    {
        switch (command.GetTurnType())
        {
            case TurnType.Move:
                SetSpriteForMoveCommand((MoveCommand)command);
                break;
            case TurnType.ChangeShape:
                SetSpriteForShapeCommand((ChangeShapeCommand)command);
                break;
        }
    }

    private void SetSpriteForMoveCommand(MoveCommand movePlayerCommand)
    {
        _image.sprite = _moveSprite;

        switch (movePlayerCommand.Direction)
        {
            case MoveDirection.Up:
                break;
            case MoveDirection.Down:
                _image.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                break;
            case MoveDirection.Left:
                _image.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                break;
            case MoveDirection.Right:
                _image.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                break;
        }
    }

    private void SetSpriteForShapeCommand(ChangeShapeCommand changePlayerShapeCommand)
    {
        switch (changePlayerShapeCommand.PlayerShape)
        {
            case PlayerShape.Cube:
                _image.sprite = _cubeSprite;
                break;
            case PlayerShape.Sphere:
                _image.sprite = _sphereSprite;
                break;
        }
    }
}