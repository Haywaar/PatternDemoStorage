using System;
using Patterns.DIExample_Zenject.Scripts;
using Patterns.DIExample_Zenject.Scripts.PlayerInput;
using Patterns.DIExample_Zenject.Scripts.Services.Calculator.DamageCalculators;
using Patterns.DIExample_Zenject.Scripts.Services.EnemyFactory;
using Patterns.DIExample_Zenject.Scripts.WeaponConfigs;
using UnityEngine;
using Zenject;

/// <summary>
/// Не обязан быть монобехом, можно в него все данные заливать конструктором
/// </summary>
public class Injector : MonoInstaller
{
    [SerializeField] private DamageVisualizer _damageVisualizer;
    
    [Header("Damage Data")]
    [SerializeField] private CalculatorType _calculatorType;
    [SerializeField] private SimpleWeaponConfig _simpleWeaponConfig;
    [SerializeField] private RangedWeaponConfig _rangedWeaponConfig;
    [SerializeField] private CritWeaponConfig _critWeaponConfig;
   
    [Header("Enemy Spawn Data")] [SerializeField]
    private EnemySpawner _spawner;
    [SerializeField] private EnemyFactoryType _enemyFactoryType;
    [SerializeField]
    private SingleEnemyFactory _singleEnemyFactory;
    [SerializeField] private RandomEnemyFactory _randomEnemyFactory;

    [SerializeField] private InputType _inputType;

    public override void InstallBindings()
    {
        Container.Bind<DamageVisualizer>().FromInstance(_damageVisualizer);
        
        var calculator = SelectCalculator(_calculatorType);
        Container.Bind<IDamageCalculator>().FromInstance(calculator);

        var factory = SelectEnemyFactory(_enemyFactoryType);
        Container.Bind<EnemyFactory>().FromInstance(factory);

        Container.Bind<EnemySpawner>().FromInstance(_spawner);

        var inputHandler = SelectInputHandler(_inputType);
        Container.Bind<InputHandler>().FromInstance(inputHandler);

        //Container.Bind(typeof(ITickable), typeof(ILateTickable), typeof(IFixedTickable)).To<TestLogScript>().AsSingle();
        Container.BindInterfacesTo<TestLogScript>().AsSingle();
    }

    /// <summary>
    /// Вообще Роберт Мартин говорит что switch-case допускается только если
    /// он используется внутри фабрики, но я решил для наглядности этот код в фабрику не запихивать
    /// </summary>
    /// <returns></returns>
    private IDamageCalculator SelectCalculator(CalculatorType calculatorType)
    {
        switch (calculatorType)
        {
            case CalculatorType.Simple:
                return new DamageCalculatorSimple(_simpleWeaponConfig);
            case CalculatorType.Range:
                return new DamageCalculatorRange(_rangedWeaponConfig);
            case CalculatorType.Crit:
                return new DamageCalculatorCritChance(_critWeaponConfig);
            default:
                return new DamageCalculatorSimple(_simpleWeaponConfig);
        }
    }

    private EnemyFactory SelectEnemyFactory(EnemyFactoryType enemyFactoryType)
    {
        switch (enemyFactoryType)
        {
            case EnemyFactoryType.Single:
                return _singleEnemyFactory;
            case EnemyFactoryType.Random:
                return _randomEnemyFactory;
            default:
                throw new ArgumentOutOfRangeException(nameof(enemyFactoryType), enemyFactoryType, null);
        }
    }

    private InputHandler SelectInputHandler(InputType inputType)
    {
        switch (inputType)
        {
            case InputType.Mouse:
                return new MouseInputHandler();
            case InputType.Keyboard_Space:
                return new KeyboardInputHandler();
            default:
                throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
        }
    }
}