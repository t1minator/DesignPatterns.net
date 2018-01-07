using ConsoleApplication1.CarsAndOffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApplication1.DecoratorPattern;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            Car hondAccord = new Car("Honda", "Accord", 18000.00);
            Car hondCivic = new Car("Honda", "Civic", 15000.00);

            List<Car> hondaList = new List<Car>();
            hondaList.Add(hondAccord);
            hondaList.Add(hondCivic);

            foreach (Car c in hondaList)
            {
                Console.WriteLine(c.toString());
            }
            
            // Special offer            
            hondAccord.DiscountPercentage = 25;
            hondAccord.Offer = "25 % discount";

            Console.WriteLine( hondAccord.toString());

            UsingDesignPattern();
            Console.ReadLine();
        }

        public static void UsingDesignPattern()
        {
            HondaCity car = new HondaCity();
            ConcreteCar hondaAccord = new ConcreteCar("Honda", "Accord", 25999.00);
            ConcreteCar hondaCivic = new ConcreteCar("Honda", "Civic", 21999.00);

            List<DecoratorPattern.Vehicle> vehicleList = new List<DecoratorPattern.Vehicle>();
            vehicleList.Add(hondaAccord);
            vehicleList.Add(hondaCivic);
            vehicleList.Add(car);

            List<SpecialOffer> specialOffers = new List<SpecialOffer>();
            foreach(DecoratorPattern.Vehicle v in vehicleList)
            {
                SpecialOffer offer = new SpecialOffer(v);
                offer.DiscountPercentage = 25;
                offer.Offer = "25 % discount";

                specialOffers.Add(offer);
            }


            foreach (SpecialOffer o in specialOffers)
            {                
                Console.WriteLine("The offer: {1} New price: {0} For {2} {3} with {4}% off.", o.Price, o.Offer, o.Make, o.Model, o.DiscountPercentage);
            }
            // Special offer
            
            //Console.WriteLine("{1} @ Diwali Special Offer and price are : {0} ", offer.Price, offer.Offer);
        }
    }
}
