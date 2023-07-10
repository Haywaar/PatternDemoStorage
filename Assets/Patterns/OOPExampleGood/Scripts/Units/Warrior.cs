namespace Patterns.IncapsulationExampleGood.Scripts.Units
{
    public class Warrior : Unit
    {
        public override int GetPrice()
        {
            if (IsThird())
            {
                return 15;
            }
            else
            {
                return 10;
            }
        }
        
        public void Attack()
        {
            // Melee Attack
        }
    }
}