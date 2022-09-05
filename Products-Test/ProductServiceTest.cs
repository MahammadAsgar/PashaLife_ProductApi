using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ProductApi.Data;
using ProductApi.Data.ViewModel;
using ProductApi.Repository;
using ProductApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Products_Test
{
    public class ProductServiceTest
    {

        private static DbContextOptions<AppDbContext> dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "ProductDb")
            .Options;
        AppDbContext context;
        ProductRepository productRepository;
        [OneTimeSetUp]
        public void Setup()
        {
            context = new AppDbContext(dbContextOptions);
            context.Database.EnsureCreated();
            SeedDatabase();
            productRepository = new ProductRepository(context);
        }

        [Test, Order(1)]
        public void GetAllProducts_Test()
        {
            var result = productRepository.GetAllProducts().ToList();
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.AreEqual(result.Count, 3);
        }

        [Test, Order(2)]
        public void GetProductById_TestWithResponse()
        {
            var result = productRepository.GetProduct(1);
            Assert.That(result.ProductId, Is.EqualTo(1));
            Assert.That(result.ProductCategoryId, Is.EqualTo(1));
            Assert.That(result.StateId, Is.EqualTo(1));
            Assert.That(result.ProductName, Is.EqualTo("first"));
            Assert.That(result.Price, Is.EqualTo(1));
            Assert.That(result.IsDeleted, Is.EqualTo(false));
            Assert.That(result.CreatedDate, Is.EqualTo(DateTime.Today));
        }

        [Test, Order(3)]
        public void AddProduct_Test()
        {
            var product = new ProductVM()
            {
                ProductCategoryId = 1,
                StateId = 1,
                ProductName ="first",
                Price = 1,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };
            var result = productRepository.AddProduct(product);
            Assert.That(result, Is.Not.Null);
        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }
        private void SeedDatabase()
        {
            var products = new List<Product>
            {
                new Product {ProductId=1, ProductCategoryId = 1,StateId =1,ProductName="first", Price=1,IsDeleted=false, CreatedDate=DateTime.Today },
                new Product {ProductId=2, ProductCategoryId = 3,StateId =2,ProductName="second", Price=1,IsDeleted=false, CreatedDate=DateTime.Today },
                new Product {ProductId=3, ProductCategoryId = 2,StateId =1,ProductName="third", Price=1,IsDeleted=false, CreatedDate=DateTime.Today },
            };
            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}