namespace Patterns.MVVMExample_Simple
{
    public class PlayerModel : Model
    {
        public PlayerModel(string name, int str, int vit, int dex, int statsToSpend) : base(name, str, vit, dex,
            statsToSpend)
        {
        }
    }
}