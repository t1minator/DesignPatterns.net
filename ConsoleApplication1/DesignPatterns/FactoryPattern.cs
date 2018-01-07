using System;
namespace ConsoleApplication1
{
    /// <summary>
    /// The 'Product' interface
    /// </summary>
    public interface IFactory
    {
        void Drive(int miles);
        void Brakes();
    }

    public class Tricycle : IFactory
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Driving " + miles + " miles");
        }

        public void Brakes()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class Scooter : IFactory
    {
        private readonly int _wheels = 2;
        public int Wheels
        {
            get
            {
                return _wheels;
            }
        }

        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Scooter : " + miles.ToString() + " miles" );
        }

        public void Brakes()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class Bike : IFactory
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Bike : " + miles.ToString() + "km");
        }

        public void Brakes()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// The Creator Abstract Class
    /// </summary>
    public abstract class VehicleFactory
    {
        public abstract IFactory GetVehicle(string Vehicle);

    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class ConcreteVehicleFactory : VehicleFactory
    {
        public override IFactory GetVehicle(string Vehicle)
        {
            switch (Vehicle)
            {
                case "Scooter":
                    return new Scooter();
                case "Bike":
                    return new Bike();
                case "Tricycle":
                    return new Tricycle();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Vehicle));
            }
        }

    }


}

