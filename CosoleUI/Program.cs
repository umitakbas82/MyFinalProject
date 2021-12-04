using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace CosoleUI
{
    //SOLID
    //OPEN CLOSED PRINCIPLE
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //CategoryTest();
            //DTOs: DATA TRANSFORMATION OBJECTS
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }

            Console.WriteLine("Hello World!");
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetProductDetails())
            {
                Console.WriteLine(product.ProductName+  "/" + product.CategoryName);
            }
        }
    }
}
