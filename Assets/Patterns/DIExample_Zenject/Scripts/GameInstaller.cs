using System;
using Patterns.DIExample_Zenject.Scripts.Services.Calculator.DamageCalculators;
using Patterns.DIExample_Zenject.Scripts.Services.EnemyFactory;
using Patterns.DIExample_Zenject.Scripts.WeaponConfigs;
using UnityEngine;
using Zenject;

namespace Patterns.DIExample_Zenject.Scripts
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private DamageVisualizer _damageVisualizer;

        [Header("Damage Data")]
        //[SerializeField] private Player _player; - Не нужон
        [SerializeField]
        private CalculatorType _calculatorType;

        [SerializeField] private SimpleWeaponConfig _simpleWeaponConfig;
        [SerializeField] private RangedWeaponConfig _rangedWeaponConfig;
        [SerializeField] private CritWeaponConfig _critWeaponConfig;

        [Header("Enemy Spawn Data")] [SerializeField]
        private EnemySpawner _spawner;

        [SerializeField] private EnemyFactoryType _enemyFactoryType;
        [SerializeField] private SingleEnemyFactory _singleEnemyFactory;
        [SerializeField] private RandomEnemyFactory _randomEnemyFactory;

        //  [Header("UI")]
        //  [SerializeField] private UILayout _layout; - Не нужон

        public override void InstallBindings()
        {
            Container.Bind<DamageVisualizer>().FromInstance(_damageVisualizer);
            
            var calculator = SelectCalculator(_calculatorType);
            Container.Bind<IDamageCalculator>().FromInstance(calculator);

            var factory = SelectEnemyFactory(_enemyFactoryType);
            Container.Bind<EnemyFactory>().FromInstance(factory);

            Container.Bind<EnemySpawner>().FromInstance(_spawner);
        }

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
    }
}