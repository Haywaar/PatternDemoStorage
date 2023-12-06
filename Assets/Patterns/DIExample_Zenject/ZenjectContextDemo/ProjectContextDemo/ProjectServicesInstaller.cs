using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectServicesInstaller : MonoInstaller
{
   [SerializeField] private ProjectTestService _projectTestService;

    public override void InstallBindings()
    {
       Container.Bind<ProjectTestService>().FromInstance(_projectTestService);
    }
}
