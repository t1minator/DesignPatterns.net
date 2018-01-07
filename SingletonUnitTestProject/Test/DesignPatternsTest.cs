using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NodaTime;
using NodaTime.Testing;
using ConsoleApplication1;
using static ConsoleApplication1.DecoratorPattern;


namespace SingletonUnitTestProject
{
    [TestClass]
    public class DesignPatternsTest
    {
        // http://csharpindepth.com/Articles/General/Singleton.aspx
        [TestMethod]
        public void NotSingletonTest()
        {
            NotSingleton s1 = new NotSingleton();
            NotSingleton s2 = new NotSingleton();

            int r1 = s1.getRandomNumber();
            int r2 = s1.getRandomNumber();

            Assert.AreNotSame(s1, s2);
        }

        [TestMethod]
        public void SingletonTest()
        {
            SimpleSingleton s1 = SimpleSingleton.CreateInstance();
            SimpleSingleton s2 = SimpleSingleton.CreateInstance();

            Singleton s3 = Singleton.Instance;

            int r1 = s1.getRandomNumber();
            int r2 = s2.getRandomNumber();

            Assert.AreSame(s1, s2);
        }

        [TestMethod]
        public void FactoryTest()
        {
            // http://www.dotnettricks.com/learn/designpatterns/factory-method-design-pattern-dotnet

            VehicleFactory factory = new ConcreteVehicleFactory();

            IFactory scooter = factory.GetVehicle("Scooter");
            scooter.Drive(10);

            IFactory bike = factory.GetVehicle("Bike");
            bike.Drive(20);

            IFactory tricycle = factory.GetVehicle("Tricycle");
            tricycle.Drive(1);

            Assert.AreNotSame(scooter,bike);
        }

        [TestMethod]
        public void BuilderTest()
        {
            // http://www.dotnettricks.com/learn/designpatterns/builder-design-pattern-dotnet
            var vehicleCreator = new VehicleCreator(new HeroBuilder());
            vehicleCreator.CreateVehicle();
            var vehicle1 = vehicleCreator.GetVehicle();
            vehicle1.ShowInfo();

            Console.WriteLine("---------------------------------------------");

            vehicleCreator = new VehicleCreator(new HondaBuilder());
            vehicleCreator.CreateVehicle();
            var vehicle2 = vehicleCreator.GetVehicle();
            vehicle2.ShowInfo();

            Assert.AreNotSame(vehicle1, vehicle2);
        }

        [TestMethod]
        public void DecoratorTest()
        {
            // http://www.dotnettricks.com/learn/designpatterns/decorator-design-pattern-dotnet

            HondaCity car = new HondaCity();

            Console.WriteLine("Honda City base price are : {0}", car.Price);

            // Special offer
            SpecialOffer offer = new SpecialOffer(car);
            offer.DiscountPercentage = 25;
            offer.Offer = "25 % discount";

            Console.WriteLine("{1} @ Diwali Special Offer and price are : {0} ", offer.Price, offer.Offer);

            Assert.AreEqual(offer.DiscountPercentage, 25);
        }

        [TestMethod]
        public void DependencyInjetionTest_Diary_utc()
        {
            Instant now = Instant.FromUtc(1970, 01, 01, 0, 0);//  SystemClock.Instance.GetCurrentInstant();
            var clock = new FakeClock(now);
            Diary diary = new Diary(clock, CalendarSystem.Iso, DateTimeZone.Utc);

            string today = diary.FormatToday();

            Assert.AreEqual("1970-01-01", today);
        }

        [TestMethod]
        public void DependencyInjetionTest_Diary_NegOffset()
        {
            // Pluralsight C# design strategies
            Instant now = Instant.FromUtc(1970, 01, 01, 0, 0);
            var zone = DateTimeZone.ForOffset(Offset.FromHours(-8));
            var clock = new FakeClock(now);
            Diary diary = new Diary(clock, CalendarSystem.Iso,zone);

            string today = diary.FormatToday();

            Assert.AreEqual("1969-12-31", today);
        }

    }
}
