using UnityEngine;
using Zenject;

public class DecoratorTestInstaller : MonoInstaller
{
    [SerializeField] private DecoratorTestServiceA decoratorTestServiceA;
    [SerializeField] private DecoratorTestServiceB decoratorTestServiceB;
    public override void InstallBindings()
    {
        Container.Bind<DecoratorTestServiceA>().FromInstance(decoratorTestServiceA);
        Container.Bind<DecoratorTestServiceB>().FromInstance(decoratorTestServiceB);
    }
}
