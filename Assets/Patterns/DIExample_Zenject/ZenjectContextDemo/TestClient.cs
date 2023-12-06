using UnityEngine;
using Zenject;

public class TestClient : MonoBehaviour
{
    [Inject]
    private TestService testService;

    [SerializeField] private int clientId;

    private void Start()
    {
        Debug.LogWarningFormat("client with id {0} received service with id {1}", clientId, testService.Value);
    }
}
