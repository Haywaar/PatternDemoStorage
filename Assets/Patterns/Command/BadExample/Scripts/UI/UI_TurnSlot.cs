using UnityEngine;
using UnityEngine.UI;

public class UI_TurnSlot : MonoBehaviour
{
    [SerializeField] private Image _image;

    // Can move in config or another script in future
    [SerializeField] private Sprite _moveSprite;
    [SerializeField] private Sprite _cubeSprite;
    [SerializeField] private Sprite _sphereSprite;

    public void Init(TurnType turnType)
    {
        SetSpriteByTurnType(turnType);
    }

    private void SetSpriteByTurnType(TurnType turnType)
    {
        switch (turnType)
        {
            case TurnType.MoveUp:
                _image.sprite = _moveSprite;
                break;
            case TurnType.MoveDown:
                _image.sprite = _moveSprite;
                _image.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                break;
            case TurnType.MoveLeft:
                _image.sprite = _moveSprite;
                _image.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                break;
            case TurnType.MoveRight:
                _image.sprite = _moveSprite;
                _image.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                break;
            case TurnType.ShapeToCube:
                _image.sprite = _cubeSprite;
                break;
            case TurnType.ShapeToSphere:
                _image.sprite = _sphereSprite;
                break;
        }
    }
}