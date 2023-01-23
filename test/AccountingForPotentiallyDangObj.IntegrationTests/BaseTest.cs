using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForPotentiallyDangObj.IntegrationTests
{
    public class BaseTest<T> 
        where T: BaseModel, new()
    {
        private AfPdoDbContext _tmContext;
        internal AfPdoRepository<T> _repository;
        internal const string  Name = "Test";


        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _tmContext = new AfPdoDbContext("Data Source=ALIVAN\\SQLEXPRESS;Initial Catalog=AccountingForPotentiallyDangObj.DataBase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False");
        }
        [SetUp]
        public void InitialiseTestsEntities()
        {
            _repository = new AfPdoRepository<T>(_tmContext);
        }
        
        [Test]
        public async Task GetAllAsyncObjects_WhenPropertiesIsNotNull_ThenOutListEntitiesFromDB()
        {
            // Arrange
            var expectedObj = new T { Name = Name };

            // Act
            var entityAdded = await _repository.AddAsync(expectedObj);
            var addedEntity = await _repository.GetAllAsync();
            var entities = addedEntity.ToList().Where(x => x.Id == expectedObj.Id).FirstOrDefault();

            // Assert
            expectedObj.Should().Be(entities);
            await _repository.DeleteAsync(expectedObj);
        }
    }
}
