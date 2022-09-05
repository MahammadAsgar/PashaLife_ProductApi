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
    public class StateServiceTest
    {

        private static DbContextOptions<AppDbContext> dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "ProductDb")
            .Options;
        AppDbContext context;
        StateRepository stateRepository;
        [OneTimeSetUp]
        public void Setup()
        {
            context = new AppDbContext(dbContextOptions);
            context.Database.EnsureCreated();
            SeedDatabase();
            stateRepository = new StateRepository(context);
        }

        [Test,Order(1)]
        public void GetAllStates_Test()
        {
            var result = stateRepository.GetAllStates().ToList();
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.AreEqual(result.Count, 3);
        }

        [Test,Order(2)]
        public void GetStateById_TestWithResponse()
        {
            var result = stateRepository.GetState(1);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Title, Is.EqualTo("New"));
        }

        [Test,Order(3)]
        public void AddState_Test()
        {
            var state = new StateVM()
            {
                StateTitle = "my State"
            };
            var result = stateRepository.AddState(state);
            Assert.That(result, Is.Not.Null);
        }
        
        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }
        private void SeedDatabase()
        {
            var states = new List<State>
            {
                new State { Id = 1,Title ="New" },
                new State { Id = 2,Title ="Avarage" },
                new State { Id = 3,Title ="Old" },
            };
            context.States.AddRange(states);
            context.SaveChanges();
        }
    }
}