using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Update()
    {
        var moveDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        _player.transform.Translate(moveDir * (Time.deltaTime * _player.MovementSpeed));
    }
}
