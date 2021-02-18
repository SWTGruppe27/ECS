using ECS.Legacy;
using NUnit.Framework;

namespace ECS.Test.Unit
{
    public class Tests
    {
        private Ecs uut;
        private FakeHeater uutFakeHeater;
        private FakeTempSensor uutFakeTempSensor;
        [SetUp]
        public void Setup()
        {
            uutFakeTempSensor = new FakeTempSensor();
            uutFakeHeater = new FakeHeater();
            uut = new Ecs(15, uutFakeTempSensor, uutFakeHeater);

        }

        [Test]
        public void GetTreshold_Treshold_Is10

        [Test]
        public void Regulate_TurnOnHeater_TurnOnCountIsOne()
        {
            uut.Regulate();
            Assert.That(uutFakeHeater.TurnOnCount, Is.EqualTo(1));
        }
    }
}