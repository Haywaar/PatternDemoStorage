using UnityEngine;

public class PlayerShapeChanger : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private MeshFilter _playerMeshFilter;
    [SerializeField] private Mesh _cubeMesh;
    [SerializeField] private Mesh _sphereMesh;

    public void SetShape(PlayerShape playerShape)
    {
        _player.SetShape(playerShape);
        var mesh = playerShape == PlayerShape.Cube ? _cubeMesh : _sphereMesh;
        _playerMeshFilter.sharedMesh = mesh;
    }

    public void Reset()
    {
        SetShape(PlayerShape.Cube);
    }
}