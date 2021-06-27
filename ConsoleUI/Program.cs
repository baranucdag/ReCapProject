using Business.Concrete;
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

            brandTest();
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
