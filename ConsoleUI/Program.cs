using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EFCarDal());
            var result =carManager.GetAllByBrandId(1);
            foreach (var items in result)
            {
                Console.WriteLine(items.CarId+"  /  "+items.Description);
            }
        }

    }
}
