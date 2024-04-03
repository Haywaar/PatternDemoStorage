using UnityEngine;
using UnityEngine.UI;

public class UI_TurnButtonPanel : MonoBehaviour
{
    [SerializeField] private Button _upButton;
    [SerializeField] private Button _downButton;
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;

    [SerializeField] private Button _swapToCubeButton;
    [SerializeField] private Button _swapToSphereButton;

    [SerializeField] private Button _playButton;
    [SerializeField] private Button _undoButton;


    [SerializeField] private TurnManager _turnManager;

    private void Awake()
    {
        _upButton.onClick.AddListener(() =>
        {
            _turnManager.AddTurn(TurnType.MoveUp);
        });

        _downButton.onClick.AddListener(() =>
        {
            _turnManager.AddTurn(TurnType.MoveDown);
        });

        _leftButton.onClick.AddListener(() =>
        {
            _turnManager.AddTurn(TurnType.MoveLeft);
        });

        _rightButton.onClick.AddListener(() =>
        {
            _turnManager.AddTurn(TurnType.MoveRight);
        });

        _swapToCubeButton.onClick.AddListener(() =>
      {
          _turnManager.AddTurn(TurnType.ShapeToCube);
      });

        _swapToSphereButton.onClick.AddListener(() =>
      {
          _turnManager.AddTurn(TurnType.ShapeToSphere);
      });

         _playButton.onClick.AddListener(() =>
      {
          _turnManager.Play();
      });

          _undoButton.onClick.AddListener(() =>
      {
          _turnManager.Undo();
      });
    }
}