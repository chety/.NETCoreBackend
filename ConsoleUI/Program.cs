using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var productManager = new ProductManager(new InMemoryProductDal());
            productManager.GetAll().ForEach(Console.WriteLine);

            Console.ReadLine();
        }
    }
}
