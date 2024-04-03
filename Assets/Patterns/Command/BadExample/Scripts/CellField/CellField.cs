using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CellField
{
    private List<CellRow> _cellRows = new List<CellRow>();

    public List<CellRow> Rows { get => _cellRows; }

    public void Clear()
    {
        _cellRows.Clear();
    }

    public void Add(CellRow cellRow)
    {
        _cellRows.Add(cellRow);
    }

    public CellType GetCellByIndex(int rowId, int columnId)
    {
        return _cellRows[rowId].Columns[columnId];
    }

    public Vector2Int GetStartPoint()
    {
        for (int i = 0; i < _cellRows.Count; i++)
        {
            for (int j = 0; j < _cellRows[i].Columns.Count; j++)
            {
                if (_cellRows[i].Columns[j] == CellType.Start)
                    return new Vector2Int(i, j);
            }
        }

        Debug.LogError("Can't find start point!");
        return new Vector2Int(-1, -1);
    }

    public Vector2Int GetExitPoint()
    {
        for (int i = 0; i < _cellRows.Count; i++)
        {
            for (int j = 0; j < _cellRows[i].Columns.Count; j++)
            {
                if (_cellRows[i].Columns[j] == CellType.Exit)
                    return new Vector2Int(i, j);
            }
        }

        Debug.LogError("Can't find exit point!");
        return new Vector2Int(-1, -1);
    }

    public bool CellExists(int rowId, int columnId)
    {
        if (rowId < 0 || columnId < 0)
            return false;

        if (rowId >= _cellRows.Count)
            return false;

        var row = _cellRows[rowId];
        if (columnId >= row.Columns.Count)
            return false;


        return true;
    }
}