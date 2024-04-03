using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaygroundCreator : MonoBehaviour
{
    [SerializeField] private Transform _rootTransform;
    [SerializeField] private float _cellSize;
    [SerializeField] private List<CellPrefab> _cellPrefabs;

    private List<GameObject> _gameObjects = new List<GameObject>();

    private CellField _field;

    public void InstantiateField(CellField cellField)
    {
        _field = cellField;

        for(int i = 0; i < _field.Rows.Count; i++)
        {
            for(int j = 0; j < _field.Rows[i].Columns.Count; j++)
            {
                //Create Empty in any case
                var prefab = GetPrefabByType(CellType.Empty);
                var go = Instantiate(prefab, _rootTransform);
                go.transform.localPosition = new Vector3(_cellSize * i, 0, _cellSize * j);
                _gameObjects.Add(go);
                
                //Create not empty
                var cellType = _field.Rows[i].Columns[j];
                if(cellType != CellType.Empty)
                {
                    var cellPrefab = GetPrefabByType(cellType);
                    go = Instantiate(cellPrefab, _rootTransform);
                    go.transform.localPosition = new Vector3(_cellSize * i, 0, _cellSize * j);
                    _gameObjects.Add(go);
                }
            }
        }
    }

    public void ClearField()
    {
        for(int i = 0; i < _gameObjects.Count; i ++)
        {
            Destroy(_gameObjects[i].gameObject);
        }
        _gameObjects.Clear();
    }

    public Vector3 GetCellPosition(Vector2Int pos)
    {
        return new Vector3(_cellSize * pos.x, 0, _cellSize * pos.y);
    }

    private GameObject GetPrefabByType(CellType cellType)
    {
        return _cellPrefabs.FirstOrDefault(x => x.type == cellType).prefab;
    }
}