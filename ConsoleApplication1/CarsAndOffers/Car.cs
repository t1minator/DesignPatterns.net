using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.CarsAndOffers
{
    public class Car
    {
        public  Car(string Make, string Model, double Price)
        {
            this.Make = Make;
            this.Model = Model;
            this.Price = Price;
        }
        public string toString()
        {
            return " Make: " + Make + " Model:  " + Model + " Price: " + Price + " Discount: " + DiscountPercentage + "% " + "Discount Price:  " + DiscountPrice + " Offer: " +  Offer;
        }
        string Make { get; set; }
        string Model { get; set; }
        double Price { get; set; }

        public int DiscountPercentage { get; set; }
        public string Offer { get; set; }

        public double DiscountPrice
        {
            get
            {
                double price = this.Price;
                int percentage = 100 - DiscountPercentage;
                return Math.Round((price * percentage) / 100, 2);
            }
        }
    }
}
