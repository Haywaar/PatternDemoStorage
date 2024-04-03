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
    [SerializeField] private CommandFabric _commandFabric;

    private void Awake()
    {

        _upButton.onClick.AddListener(() =>
        {
            // You can set parameters directly...
            _turnManager.AddTurn(_commandFabric.CreateMoveCommand(MoveDirection.Up, 1));
        });

        _downButton.onClick.AddListener(() =>
        {
            _turnManager.AddTurn(_commandFabric.CreateMoveCommand(MoveDirection.Down, 1));
        });

        _leftButton.onClick.AddListener(() =>
        {
            // Or move this responsibility to fabric
            _turnManager.AddTurn(_commandFabric.CreateMoveLeftCommand());
        });

        _rightButton.onClick.AddListener(() =>
        {
            _turnManager.AddTurn(_commandFabric.CreateMoveRightCommand());
        });

        _swapToCubeButton.onClick.AddListener(() =>
      {
          _turnManager.AddTurn(_commandFabric.CreateChangeShapeCommand(PlayerShape.Cube));
      });

        _swapToSphereButton.onClick.AddListener(() =>
      {
          _turnManager.AddTurn(_commandFabric.CreateChangeShapeCommand(PlayerShape.Sphere));
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