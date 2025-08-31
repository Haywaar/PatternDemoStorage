namespace Patterns.OOPExampleGood.Scripts.EncapsulationDemo
{
    public class PseudoEnemyScript_v1
    {
        // мы его как то в этот класс передаем
        private Player_v1 _player;
        
        public void DamagePlayer(double damage)
        {
            _player.TakeDamage(damage);
        }
    }
}