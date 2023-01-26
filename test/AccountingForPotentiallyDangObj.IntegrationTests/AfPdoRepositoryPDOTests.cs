using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using FluentAssertions;
using System;

namespace AccountingForPotentiallyDangObj.IntegrationTests
{
    public class AfPdoRepositoryPDOTests : BaseDictionaryTest<PDO>
    {
        [Test]
        public override async Task GetAllAsyncObjects_WhenPropertiesIsNotNull_ThenOutListEntitiesFromDB()
        {
            // Arrange
            var expectedObj = new PDO 
            { Name = Name,
              JournalPdoId = 1,
              RegistrationNumber = 2545,
              TypeId = 2,
              DateOfRegistration = DateTime.Now,
              TechnicalSpecification = new TechnicalSpecification(),
             InspectorId = 2,
              TechnicalConditionalId = 2,
              SubjectId = 2,
              InstallationLocation = new InstallationLocation()
            };

            // Act
            await _repository.AddAsync(expectedObj);
            var entities = _repository.GetAll().ToList().Where(x => x.Id == expectedObj.Id).FirstOrDefault();
            var testGetById = _repository.GetByIdAsync(expectedObj.Id).Result;
            //var tex = testGetById.ToList().FirstOrDefault().TechnicalSpecification.Id;

            // Assert
            expectedObj.Should().Be(entities);
            await _repository.DeleteAsync(expectedObj);
            await DeleteEntitiesAfterTests(expectedObj.TechnicalSpecification);
            await DeleteEntitiesAfterTests(expectedObj.InstallationLocation);
        }
        [Test]
        public override async Task AddAsyncObject_WhenPropertiesIsNotNull_ThenOutIsListEntitiesFromDB()
        {
            // Arrange
            var expectedObj = new PDO
            {
                Name = Name,
                JournalPdoId = 1,
                RegistrationNumber = 2545,
                TypeId = 2,
                DateOfRegistration = DateTime.Now,
                TechnicalSpecification = new TechnicalSpecification(),
                InspectorId = 2,
                TechnicalConditionalId = 2,
                SubjectId = 2,
                InstallationLocation = new InstallationLocation()
            };
            // Act
            await _repository.AddAsync(expectedObj);
            var entities = _repository.GetAll().ToList().Where(x => x.Id == expectedObj.Id).FirstOrDefault();

            //Assert
            entities.Should().Be(expectedObj);
            await _repository.DeleteAsync(expectedObj);
            await DeleteEntitiesAfterTests(expectedObj.TechnicalSpecification);
            await DeleteEntitiesAfterTests(expectedObj.InstallationLocation);
        }

        [Test]
        public override async Task UpdateAsyncObject_WhenPropertiesIsNotNull_ThenOpdateIsListEntitiesFromDB()
        {
            // Arrange
            var expectedObj = new PDO
            {
                Name = Name,
                JournalPdoId = 1,
                RegistrationNumber = 2545,
                TypeId = 2,
                DateOfRegistration = DateTime.Now,
                TechnicalSpecification = new TechnicalSpecification(),
                InspectorId = 2,
                TechnicalConditionalId = 2,
                SubjectId = 2,
                InstallationLocation = new InstallationLocation()
            };

            // Act
            await _repository.AddAsync(expectedObj);
            expectedObj.Name = NameUpdate;
            var expectedObjUpdate = await _repository.UpdateAsync(expectedObj);
            var entities = _repository.GetAll().ToList().Where(x => x.Id == expectedObj.Id).FirstOrDefault();

            //Assert
            entities.Should().Be(expectedObjUpdate);
            await _repository.DeleteAsync(expectedObjUpdate);
            await DeleteEntitiesAfterTests(expectedObj.TechnicalSpecification);
            await DeleteEntitiesAfterTests(expectedObj.InstallationLocation);
        }
        [Test]
        public override async Task GetByIdAsyncObject_WhenPropertiesIsNotNull_ThenDeleteIsListEntitiesFromDB()
        {
            //Arrange
            var expectedObj = new PDO
            {
                Name = Name,
                JournalPdoId = 1,
                RegistrationNumber = 2545,
                TypeId = 2,
                DateOfRegistration = DateTime.Now,
                TechnicalSpecification = new TechnicalSpecification(),
                InspectorId = 2,
                TechnicalConditionalId = 2,
                SubjectId = 2,
                InstallationLocation = new InstallationLocation()
            };

            //Act
            await _repository.AddAsync(expectedObj);
            var entities = (await _repository.GetByIdAsync(expectedObj.Id)).ToList().FirstOrDefault();

            //Assert
            entities.Should().Be(expectedObj);
            await _repository.DeleteAsync(expectedObj);
            await DeleteEntitiesAfterTests(expectedObj.TechnicalSpecification);
            await DeleteEntitiesAfterTests(expectedObj.InstallationLocation);
        }
        [Test]
        public override async Task DeleteAsyncObject_WhenPropertiesIsNotNull_ThenDeleteIsListEntitiesFromDB()
        {
            //Arrange
            var expectedObj = new PDO
            {
                Name = Name,
                JournalPdoId = 1,
                RegistrationNumber = 2545,
                TypeId = 2,
                DateOfRegistration = DateTime.Now,
                TechnicalSpecification = new TechnicalSpecification(),
                InspectorId = 2,
                TechnicalConditionalId = 2,
                SubjectId = 2,
                InstallationLocation = new InstallationLocation()
            };

            //Act
            var expectedObjAdded = await _repository.AddAsync(expectedObj);
            await _repository.DeleteAsync(expectedObjAdded);
            var entities = await _repository.GetByIdAsync(expectedObj.Id);

            //Assert
            entities.Should().BeEmpty();
            await DeleteEntitiesAfterTests(expectedObj.TechnicalSpecification);
            await DeleteEntitiesAfterTests(expectedObj.InstallationLocation);
        }

    }
}