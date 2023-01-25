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
    public class BaseDictionaryTest<T> : BaseTest
        where T: BaseModel, new()
    {
        internal AfPdoRepository<T> _repository;
        internal const string  Name = "Test";


        [SetUp]
        public void InitialiseTestsEntities()
        {
            _repository = new AfPdoRepository<T>(_tmContext);
        }
        
        [Test]
        public virtual async Task GetAllAsyncObjects_WhenPropertiesIsNotNull_ThenOutListEntitiesFromDB()
        {
            // Arrange
            var expectedObj = new T { Name = Name };

            // Act
            var entityAdded = await _repository.AddAsync(expectedObj);
            var addedEntity = _repository.GetAll();
            var entities = addedEntity.ToList().Where(x => x.Id == expectedObj.Id).FirstOrDefault();

            // Assert
            expectedObj.Should().Be(entities);
            await _repository.DeleteAsync(expectedObj);
        }
    }
}
