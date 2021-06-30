using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            carTest();

            colourTest();

            //brandTest();

            //customerTest();

            rentalTest();

            userTest();

            CarManager carManager = new CarManager(new EFCarDal());
            var result = carManager.GetCarDetails();
            foreach (var item in result)
            {
                Console.WriteLine("car Id:"+item.CarId+" colour Name:"+item.ColourName+" brand Name:"+item.BrandName+" model Year"+item.ModelYear);
            }
        }

        private static void userTest()
        {
            UserManager userManager = new UserManager(new EFUserDal());
            var resultUser = userManager.GetAll();
            foreach (var items in resultUser)
            {
                Console.WriteLine(items.FirstName + items.LastName);
            }
        }

        private static void rentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EFRentalDal());
            var resultRental = rentalManager.GetAll();
            foreach (var items in resultRental)
            {
                Console.WriteLine(items.RentalId + items.CarId );
            }
        }

        private static void customerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EFCustomerDal());
            var resultCustomer = customerManager.GetAll();
            foreach (var items in resultCustomer)
            {
                Console.WriteLine(items.CustomerId + items.CompanyName);
            }
        }

        private static void brandTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            var resultBrand = brandManager.GetAll();
            foreach (var brands in resultBrand)
            {
                Console.WriteLine("\nBrand Name: " + brands.BrandName + "Brand Id: " + brands.BrandId);
            }
        }

        private static void colourTest()
        {
            ColourManager colourManager = new ColourManager(new EFColourDal());
            var resultColour = colourManager.GetAll();
            foreach (var colours in resultColour)
            {
                Console.WriteLine("Colour Name: " + colours.ColourName + "   colour Id: " + colours.ColourId);
            }

        }

        private static void carTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            var result = carManager.GetAllByBrandId(1);
            foreach (var items in result)
            {
                Console.WriteLine(items.CarId + "  /  " + items.Description + "\n ");
            }
        }
    }
}
