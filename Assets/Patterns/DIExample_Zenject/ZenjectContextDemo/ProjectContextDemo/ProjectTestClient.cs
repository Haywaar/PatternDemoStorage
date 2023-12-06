using UnityEngine;
using Zenject;

public class ProjectTestClient : MonoBehaviour
{
   [Inject]
    private ProjectTestService testService;

    [SerializeField] private int clientId;

    private void Start()
    {
        Debug.LogWarningFormat("client with id {0} received service with id {1}", clientId, testService.Value);
    }
}
