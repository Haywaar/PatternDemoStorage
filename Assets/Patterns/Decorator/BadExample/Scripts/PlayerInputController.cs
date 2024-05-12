using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _player.Shoot();
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        var moveDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        _player.transform.Translate(moveDir * (Time.deltaTime * _player.MovementSpeed));
    }
}