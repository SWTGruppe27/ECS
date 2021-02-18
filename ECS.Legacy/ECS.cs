namespace ECS.Legacy
{
    public class Ecs
    {
        private int _threshold;
        public int _upperTreshold { get; private set; }
        private readonly ITempSensor _tempSensor;
        private readonly IHeater _heater;
        private readonly IWindow _window;

        public Ecs(int thr, int upperThr, ITempSensor tempSensor, IHeater heater, IWindow window)
        {
            SetThreshold(thr);
            _tempSensor = tempSensor;
            _heater = heater;
            _window = window;
            _upperTreshold = upperThr;

        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            if (t < _threshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();

            if (t >  _upperTreshold)
            {
                _window.Open();
            }
            else
            {
                _window.Close();
            }

        }

        public void SetThreshold(int thr)
        {
            _threshold = thr;
        }

        public int GetThreshold()
        {
            return _threshold;
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}
