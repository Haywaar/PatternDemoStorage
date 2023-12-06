using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller
{
    [SerializeField] private TestService testService;
    public override void InstallBindings()
    {
        Container.Bind<TestService>().FromInstance(testService);
        Debug.LogWarning("bind successful!");
    }
}
