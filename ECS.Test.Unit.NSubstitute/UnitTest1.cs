using NSubstitute;
using NUnit.Framework;
using ECS.Legacy;

namespace ECS.Test.Unit.NSubstitute
{
    public class Tests
    {
        private Ecs uut;
        private IHeater uutHeater;
        private ITempSensor uutTempSensor;
        private IWindow uutWindow;

        [SetUp]
        public void Setup()
        {
            uutHeater = Substitute.For<IHeater>();
            uutTempSensor = Substitute.For<ITempSensor>();
            uutWindow = Substitute.For<IWindow>();

            uut = new Ecs(25, 30, uutTempSensor, uutHeater, uutWindow);
        }

        [Test]
        public void GetThreshold_Threshold_Is10()
        {
            uut.SetThreshold(10);
            Assert.That(uut.GetThreshold(), Is.EqualTo(10));
        }

        [Test]
        public void setThreshold_Threshold_Is5()
        {
            uut.SetThreshold(5);
            Assert.That(uut.GetThreshold(), Is.EqualTo(5));
        }

        [Test]
        public void getTemp_temp_Is10()
        {
            uutTempSensor.GetTemp().Returns(10);
            Assert.That(uut.GetCurTemp(), Is.EqualTo(10));
        }

        [Test]
        public void RunSelfTest_retuns_true()
        {
            uutTempSensor.RunSelfTest().Returns(true);
            uutHeater.RunSelfTest().Returns(true);
            Assert.That(uut.RunSelfTest, Is.True);
        }

        [Test]
        public void RunSelfTest_retuns_OneIsFalse()
        {
            uutTempSensor.RunSelfTest().Returns(true);
            uutHeater.RunSelfTest().Returns(false);
            Assert.That(uut.RunSelfTest, Is.False);
        }
        [Test]
        public void RunSelfTest2_retuns_OneIsFalse()
        {
            uutTempSensor.RunSelfTest().Returns(false);
            uutHeater.RunSelfTest().Returns(true);
            Assert.That(uut.RunSelfTest, Is.False);
        }


        [Test]
        public void Regulate_TempBelowThreshold_HeaterTurnedOn()
        {
            uutTempSensor.GetTemp().Returns(20);
            uut.Regulate();
            uutHeater.Received(1).TurnOn();
        }

        [Test]
        public void Regulate_TempOverThreshold_HeaterTurnedOff()
        {
            uutTempSensor.GetTemp().Returns(26);
            uut.Regulate();
            uutHeater.Received(1).TurnOff();
        }

        [Test]
        public void Regulate_TempOverUpperThreshold_OpenWindow()
        {
            uutTempSensor.GetTemp().Returns(31);
            uut.Regulate();
            uutWindow.Received(1).Open();
        }

        [Test]
        public void Regulate_TempUnderUpperThreshold_CloseWindow()
        {
            uutTempSensor.GetTemp().Returns(29);
            uut.Regulate();
            uutWindow.Received(1).Close();
        }

    }
}