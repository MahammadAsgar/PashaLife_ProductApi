using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ProductApi.Data;
using ProductApi.Data.ViewModel;
using ProductApi.Repository;
using ProductApi.Services;
using System.Collections.Generic;
using System.Linq;

namespace Products_Test
{
    public class CategoryServiceTest
    {

        private static DbContextOptions<AppDbContext> dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "ProductDb")
            .Options;
        AppDbContext context;
        ProductCategoryRepository categoryRepository;
        [OneTimeSetUp]
        public void Setup()
        {
            context = new AppDbContext(dbContextOptions);
            context.Database.EnsureCreated();
            SeedDatabase();
            categoryRepository = new ProductCategoryRepository(context);
        }

        [Test, Order(1)]
        public void GetAllCategories_Test()
        {
            var result = categoryRepository.GetAllProductCategories().ToList();
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.AreEqual(result.Count, 3);
        }

        [Test, Order(2)]
        public void GetCategoryById_TestWithResponse()
        {
            var result = categoryRepository.GetProductCategory(1);
            Assert.That(result.ProductCategoryId, Is.EqualTo(1));
            Assert.That(result.ProductCategoryName, Is.EqualTo("first"));
        }

        [Test, Order(3)]
        public void AddCategory_Test()
        {
            var category = new ProductCategoryVM()
            {
                ProductCategoryName = "my Category"
            };
            var result = categoryRepository.AddProductCategory(category);
            Assert.That(result, Is.Not.Null);
        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }
        private void SeedDatabase()
        {
            var categories = new List<ProductCategory>
            {
                new ProductCategory { ProductCategoryId = 1,ProductCategoryName ="first" },
                new ProductCategory { ProductCategoryId = 2,ProductCategoryName ="second" },
                new ProductCategory { ProductCategoryId = 3,ProductCategoryName ="third" },
            };
            context.ProductCategories.AddRange(categories);
            context.SaveChanges();
        }
    }
}