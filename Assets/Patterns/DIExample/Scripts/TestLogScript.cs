using UnityEngine;

public class TestLogScript : MonoBehaviour
{
    private void Update()
    {
        Debug.LogWarning("update");
    }

    private void LateUpdate()
    {
        Debug.LogWarning("late update");
    }

    private void FixedUpdate()
    {
        Debug.LogWarning("fixed update");
    }
}
