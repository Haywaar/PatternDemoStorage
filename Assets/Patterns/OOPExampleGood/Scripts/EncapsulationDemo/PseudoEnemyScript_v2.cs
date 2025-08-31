namespace Patterns.OOPExampleGood.Scripts.EncapsulationDemo
{
    public class PseudoEnemyScript_v2
    {
        private Player_v2 _player;
        
        public void DamagePlayer(double damage)
        {
            _player.TakeDamage(damage);
        }
    }
}