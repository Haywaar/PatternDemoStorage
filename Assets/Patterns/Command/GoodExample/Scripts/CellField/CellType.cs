[System.Serializable]
public enum CellType
{
    Empty = 0,
    Start = 1,
    Exit = 2,
    /// <summary>
    /// Can't pass
    /// </summary>
    Block = 3,
    /// <summary>
    /// Can pass only in cube form
    /// </summary>
    FilterCube = 4,
    /// <summary>
    /// Can pass only in sphere form
    /// </summary>
    FilterSphere = 5,
}
