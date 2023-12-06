using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DecoratorTestClient_1 : MonoBehaviour
{
    [Inject]
    private DecoratorTestServiceA testServiceA;

    [Inject]
    private DecoratorTestServiceB testServiceB;

    private void Start()
    {
        Debug.LogWarningFormat("testServiceA value {0}", testServiceA.Value);
        Debug.LogWarningFormat("testServiceB value {0}", testServiceB.Value);
    }
}
