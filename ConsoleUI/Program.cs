using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //CategoryTest();
        }

        private static void ProductTest()
        {
            var productManager = new ProductManager(new EfProductDal());
            foreach (var  productDetail in productManager.GetProductDetails())
            {
                Console.WriteLine($"Name: {productDetail.ProductName} ---  Category: {productDetail.CategoryName}");
            }
            
        }

        private static void CategoryTest()
        {
            var categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine($"{category.CategoryId} -> {category.CategoryName}");

            }
        }
    }
}
