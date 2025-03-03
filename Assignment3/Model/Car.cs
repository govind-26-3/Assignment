using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Model
{
    internal class Car
    {
        int carId;
        string brand;
        string model;
        int year;
        double price;

        public void AcceptCarInformation()
        {
            Console.WriteLine("Enter car id");
            carId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter car Brand");
            brand = Console.ReadLine();

            Console.WriteLine("Enter Car Nodel name");
            model = Console.ReadLine();

            Console.WriteLine("Enter manufacturing year");
            year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter car price");
            price = Convert.ToDouble(Console.ReadLine());
        }

        public void DisplayingCarInformation()
        {
            Console.WriteLine($"CarID ::{carId}  Brand :: {brand}   Model::{model}   manufacturing year::{year}   cost of the car::{price}");
        }
    }
}
