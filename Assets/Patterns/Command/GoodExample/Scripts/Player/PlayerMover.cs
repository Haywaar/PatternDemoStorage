using UnityEngine;

//Receiver
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlaygroundLoader _playgroundLoader;
    [SerializeField] private PlaygroundCreator _playgroundCreator;
    [SerializeField] private Player _player;

    private CellField _cellField;
    private Vector2Int _startPoint;

    private void Start()
    {

        Reset();
    }

    public bool Move(int xDelta, int yDelta)
    {
        if (!CanBeMoved(xDelta, yDelta))
        {
            return false;
        }

        Vector2Int newPos = new Vector2Int(_player.Pos.x + xDelta, _player.Pos.y + yDelta);
        _player.SetPos(newPos);
        _player.transform.localPosition = _playgroundCreator.GetCellPosition(newPos);

        return true;
    }

    public bool CanBeMoved(int xDelta, int yDelta)
    {
        Vector2Int newPos = new Vector2Int(_player.Pos.x + xDelta, _player.Pos.y + yDelta);

        if (!_cellField.CellExists(newPos.x, newPos.y))
            return false;

        var cellType = _cellField.GetCellByIndex(newPos.x, newPos.y);
        if (cellType == CellType.Block)
            return false;

        if (!ShapeFits(cellType))
            return false;

        return true;
    }

    private bool ShapeFits(CellType cellType)
    {
        if (cellType == CellType.FilterCube && _player.Shape == PlayerShape.Sphere)
            return false;

        if (cellType == CellType.FilterSphere && _player.Shape == PlayerShape.Cube)
            return false;

        return true;
    }

    public void Reset()
    {
        _cellField = _playgroundLoader.CellField;
        _startPoint = _cellField.GetStartPoint();
        _player.SetPos(_startPoint);
        _player.transform.localPosition = _playgroundCreator.GetCellPosition(_startPoint);
    }
}