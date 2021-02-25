using ECS.Legacy;
using NUnit.Framework;

namespace ECS.Test.Unit
{
    public class Tests
    {
        private Ecs uut;
        private FakeHeater uutFakeHeater;
        private FakeTempSensor uutFakeTempSensor;
        private FakeWindow uutFakeWindow;

        [SetUp]
        public void Setup()
        {
            uutFakeTempSensor = new FakeTempSensor();
            uutFakeHeater = new FakeHeater();
            uutFakeWindow = new FakeWindow();
            uut = new Ecs(15, 25, uutFakeTempSensor, uutFakeHeater, uutFakeWindow);

        }

        [Test]
        public void GetThreshold_Threshold_Is10()
        {
            Assert.That(uut.GetThreshold(),Is.EqualTo(15));
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
            Assert.That(uut.GetCurTemp(), Is.EqualTo(10));
        }

        [Test]
        public void RunSelfTest_retuns_true()
        {
            Assert.That(uut.RunSelfTest,Is.True);
        }

        [Test]
        public void Regulate_TurnOnHeater_TurnOnCountIsOne()
        {
            uut.Regulate();
            Assert.That(uutFakeHeater.TurnOnCount, Is.EqualTo(1));
        }

        [Test]
        public void Regulate_CloseWindow_CloseWindowCountIs1()
        {
            uut.Regulate();
            Assert.That(uutFakeWindow.CloseWindowCount, Is.EqualTo(1));
        }

        [Test]
        public void Regulate_OpenWindow_OpenWindowCountIs1()
        {
            uut._upperTreshold = 2;
            uut.Regulate();
            Assert.That(uutFakeWindow.OpenWindowCount, Is.EqualTo(1));
        }
    }
}