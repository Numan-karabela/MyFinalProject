﻿using Business.Concreet;
using DataAccess.Abstract;
using DataAccess.Concreet.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
        //    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        //    foreach (var category in categoryManager.GetAll())
        //    {
        //        Console.WriteLine(category.CategoryName);

        //    }


        //    ProductTest();

        //}
        //private static void ProductTest()
        //{
        //    ProductManager productManager = new ProductManager(new EfProductDal());

        //    var result = productManager.GetProductsDetails();
        //    if (result.Succees == true)
        //    {
        //        foreach (var product in productManager.GetProductsDetails().Data)
        //        {
        //            Console.WriteLine(product.ProductName + "/" + product.CategoryName);
        //        }

        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }


        }
    }
}