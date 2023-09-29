using UnityEngine;
using UnityEngine.UI;

namespace Patterns.DIExample.Scripts
{
    /// <summary>
    /// Простенький скрипт который отображает тип калькулятора и счётчик убитых монстров
    /// </summary>
    public class UILayout : MonoBehaviour
    {
        [SerializeField] private Text _calculatorText;
        [SerializeField] private Text _killedMobsCount;

        public void Construct(EnemySpawner spawner, IDamageCalculator calculator)
        {
            _calculatorText.text = calculator.GetDescription();
            spawner.OnMobKilled += OnMobKilled;
        }

        private void OnMobKilled(int count)
        {
            _killedMobsCount.text = string.Format("Killed mobs count: {0}", count);
        }
    }
}