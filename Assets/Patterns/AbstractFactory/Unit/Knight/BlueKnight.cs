namespace Examples.AbstractFactoryExample.Unit.Knight
{
    public class BlueKnight : Knight
    {
        private float _koef1;
        private float _koef2;
        public void Init(float koef1, float koef2)
        {
            _koef1 = koef1;
            _koef2 = koef2;
        }

        public override void Parry()
        {
            // do something
        }
    }
}