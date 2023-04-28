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
        internal const string Name = "Test";
        internal const string NameUpdate = "TestUpdate";


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
            var entityAdded = await _repository.CreateAsync(expectedObj);
            var entities = _repository.GetAll().ToList().Where(x => x.Id == expectedObj.Id).FirstOrDefault();

            // Assert
            expectedObj.Should().Be(entities);
            await _repository.DeleteAsync(expectedObj);
        }

        [Test]
        public virtual async Task AddAsyncObject_WhenPropertiesIsNotNull_ThenOutIsListEntitiesFromDB()
        {
            // Arrange
            var expectedObj = new T { Name = Name };

            // Act
            await _repository.CreateAsync(expectedObj);
            var entities = _repository.GetAll().ToList().Where(x => x.Id == expectedObj.Id).FirstOrDefault();

            //Assert
            entities.Should().Be(expectedObj);
            await _repository.DeleteAsync(expectedObj);
        }

        [Test]
        public virtual async Task UpdateAsyncObject_WhenPropertiesIsNotNull_ThenOpdateIsListEntitiesFromDB()
        {
            // Arrange
            var expectedObj = new T { Name = Name };

            // Act
            await _repository.CreateAsync(expectedObj);
            expectedObj.Name = NameUpdate;
            var expectedObjUpdate = await _repository.UpdateAsync(expectedObj);
            var entities = _repository.GetAll().ToList().Where(x => x.Id == expectedObj.Id).FirstOrDefault();
            
            //Assert
            entities.Should().Be(expectedObjUpdate);
            await _repository.DeleteAsync(expectedObjUpdate);
        }

        [Test]
        public virtual async Task GetByIdAsyncObject_WhenPropertiesIsNotNull_ThenDeleteIsListEntitiesFromDB()
        {
            //Arrange
            var expectedObj = new T { Name = Name };

            //Act
            await _repository.CreateAsync(expectedObj);
            var entities = (await _repository.GetByIdAsync(expectedObj.Id));

            //Assert
            entities.Should().Be(expectedObj);
            await _repository.DeleteAsync(expectedObj);
        }

        [Test]
        public virtual async Task DeleteAsyncObject_WhenPropertiesIsNotNull_ThenDeleteIsListEntitiesFromDB()
        {
            //Arrange
            var expectedObj = new T { Name = Name };

            //Act
            var expectedObjAdded = await _repository.CreateAsync(expectedObj);
            await _repository.DeleteAsync(expectedObjAdded);
            var entities = await _repository.GetByIdAsync(expectedObj.Id);

            //Assert
            entities.Should().BeNull();
        }
    }
}
