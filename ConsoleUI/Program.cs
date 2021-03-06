﻿using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //UsersTest();
            //CustomersTest();
            //RentalsTest();

        }

        private static void RentalsTest()
        {
            RentalsManager rentalsManager = new RentalsManager(new EfRentalsDal());
            DateTime rentDate = new DateTime(2015, 12, 25);
            DateTime returnDate = new DateTime(2018, 10, 18);
            Rentals rentals = new Rentals
            {
                CustomerId = 1,
                CarId = 2,
                RentDate = rentDate,
                ReturnDate = returnDate
            };
            var result = rentalsManager.AddRental(rentals);
            if (result.Success)
            {
                Console.WriteLine("Araç kiralandı");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CustomersTest()
        {
            CustomersManager customersManager = new CustomersManager(new EfCustomersDal());
            Customers customer = new Customers
            {
                UserId = 1,
                CompanyName = "HepsiBurada"
            };
            var result = customersManager.GetCustomersDetails();
            if (result.Success)
            {
                Console.WriteLine("*****Müşteriler*****\n");
                foreach (var customers in result.Data)
                {
                    Console.WriteLine(customers.FirstName + " " + customers.LastName + " " + customers.CompanyName +"\n");
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine("Beklenmeyen Hata.");
            }
        }

        private static void UsersTest()
        {
            UserManager usersManager = new UserManager(new EfUserDal());
            User user = new User
            {
                FirstName = "Taylan Deniz",
                LastName = "Arslan",
                Email = "tdarslan@gmail.com",
            };
            var result = usersManager.GetAll();
            if (result.Success)
            {
                foreach (var users in result.Data)
                {
                    Console.WriteLine(users.FirstName + " " + users.LastName + "\n");
                }
            }
            else
            {
                Console.WriteLine("Beklenmedik Hata.");
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId);
            }
            Console.WriteLine("Hello world!");
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal(),new BrandManager(new EfBrandDal()));

            var result = carManager.GetCarDetails2();
            if(result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId + " " + car.BrandName + " " + car.ColorName + " " + car.Description + " " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
