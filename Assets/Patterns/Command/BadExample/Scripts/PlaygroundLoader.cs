using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaygroundLoader : MonoBehaviour
{
    [SerializeField] private List<TextAsset> _levelConfigs;
    [SerializeField] private CellField _cellField;
    [SerializeField] private PlaygroundCreator _playgroundCreator;

    public CellField CellField { get => _cellField; }
    private int _levelId = 0;

    public void LoadNextLevel()
    {
        _levelId++;

        // Cycling game
        if (_levelId >= _levelConfigs.Count)
        {
            _levelId = 0;
        }
        _cellField.Clear();
        _playgroundCreator.ClearField();
        LoadCurrentLevel();
    }

    private void LoadCurrentLevel()
    {
        CreateCellField(_levelConfigs[_levelId]);
        _playgroundCreator.InstantiateField(_cellField);
    }

    private void Awake()
    {
        LoadCurrentLevel();
    }

    private void CreateCellField(TextAsset textAsset)
    {
        List<string> rows = new List<string>();

        if (textAsset != null)
        {
            rows = textAsset.text.Split("\n").ToList();
        }

        foreach (var row in rows)
        {
            var columns = row.Split(",").ToList();
            var cellRow = new CellRow();
            foreach (var data in columns)
            {
                var cType = GetCellType(data);
                cellRow.Columns.Add(cType);
            }
            _cellField.Add(cellRow);
        }
    }

    private CellType GetCellType(string str)
    {
        str = str.Trim();

        switch (str)
        {
            case "St":
                return CellType.Start;
            case "Ex":
                return CellType.Exit;
            case "Bl":
                return CellType.Block;
            case "Cb":
                return CellType.FilterCube;
            case "Sp":
                return CellType.FilterSphere;
            case "Em":
                return CellType.Empty;
            default:
                Debug.LogError("unknown type:" + str);
                return CellType.Empty;
        }
    }

}
