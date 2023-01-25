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
              YearOfManufacture = 2022,
              TechnicalSpecification = new TechnicalSpecification(),
              //TechnicalSpecificationId = 5,
              ServiceLife = 25,
              InspectorId = 2,
              TechnicalConditionalId = 2,
              SubjectId = 2,
              InstallationLocationId = 8,
            };

            // Act
            var entityAdded = await _repository.AddAsync(expectedObj);
            var addedEntity = _repository.GetAll();
            var entities = addedEntity.ToList().Where(x => x.Id == expectedObj.Id).FirstOrDefault();
            var testGetById = _repository.GetByIdAsync(expectedObj.Id).Result;
            //var tex = testGetById.ToList().FirstOrDefault().TechnicalSpecification.Id;

            // Assert
            expectedObj.Should().Be(entities);
            await _repository.DeleteAsync(expectedObj);
            await DeleteEntitiesAfterTests(expectedObj.TechnicalSpecification);


        }

    }
}