namespace Patterns.MVVMExample_Simple
{
    public abstract class Model
    {
        public readonly string PlayerName;
        public readonly ReactiveProperty<int> STR = new();
        public readonly ReactiveProperty<int> VIT = new();
        public readonly ReactiveProperty<int> DEX = new();

        private int _clanRating;
        private int _clanID;
        private int _clanRole;
        private int _goldCount;
        public int ClanRating => _clanRating;
        public int ClanID => _clanID;
        public int ClanRole => _clanRole;
        public int GoldCount => _goldCount;

        private int _statsToSpend;

        public int StatsToSpend
        {
            get => _statsToSpend;
            set => _statsToSpend = value;
        }

        public Model(string name, int str, int vit, int dex, int statsToSpend)
        {
            PlayerName = name;
            STR.Value = str;
            VIT.Value = vit;
            DEX.Value = dex;
            _statsToSpend = statsToSpend;
        }
    }
}