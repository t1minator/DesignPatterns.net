using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public  class DecoratorPattern
    {
        /// <summary>
        /// The 'Component' interface
        /// </summary>
        public interface Vehicle
        {
            string Make { get; }
            string Model { get; }
            double Price { get; }
        }

        /// <summary>
        /// The 'ConcreteComponent' class
        /// </summary>
        public class ConcreteCar : Vehicle
        {
            public ConcreteCar(string make, string model, double price)
            {
                this._make = make;
                this._model = model;
                this._price = price;
            }
            private string _make;
            public string Make
            {
                get { return _make; }
            }

            private string _model;
            public string Model
            {
                get { return _model; }
            }
            private double _price;
            public double Price
            {
                get { return _price; }
            }
        }
        /// <summary>
        /// The 'ConcreteComponent' class
        /// </summary>
        public class HondaCity : Vehicle
        {
            private string _make;
            public string Make
            {
                get { return "HondaCity"; }
            }

            private string _model;
            public string Model
            {
                get { return "CNG"; }
            }
            private double _price;
            public double Price
            {
                get { return 1000000; }
            }
        }

        /// <summary>
        /// The 'Decorator' abstract class
        /// </summary>
        public abstract class VehicleDecorator : Vehicle
        {
            private Vehicle _vehicle;

            public VehicleDecorator(Vehicle vehicle)
            {
                _vehicle = vehicle;
            }

            public string Make
            {
                get { return _vehicle.Make; }
            }

            public string Model
            {
                get { return _vehicle.Model; }
            }

            public double Price
            {
                get { return _vehicle.Price; }
            }

        }

        /// <summary>
        /// The 'ConcreteDecorator' class
        /// </summary>
        public class SpecialOffer : VehicleDecorator
        {
            public SpecialOffer(Vehicle vehicle) : base(vehicle) { }

            public int DiscountPercentage { get; set; }
            public string Offer { get; set; }

            public double Price
            {
                get
                {
                    double price = base.Price;
                    int percentage = 100 - DiscountPercentage;
                    return Math.Round((price * percentage) / 100, 2);
                }
            }

        }

       
    }
}
