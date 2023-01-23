using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using FluentAssertions;

namespace AccountingForPotentiallyDangObj.IntegrationTests
{
    public class AfPdoRepositoryInspectorTests : BaseTest<Inspector>
    {
                      
        [Test]
        public async Task AddAsyncObject_WhenPropertiesIsNotNull_ThenOutIsListEntitiesFromDB()
        {
            // Arrange
            var addingInspector = new Inspector { Name = "Rafalsky D." };

            // Act
            await _repository.AddAsync(addingInspector);
            var addedInspector = (await _repository.GetByIdAsync(addingInspector.Id)).ToList().FirstOrDefault();

            //Assert
            addedInspector.Should().Be(addingInspector);
            await _repository.DeleteAsync(addingInspector);
        }

        [Test]
        public async Task UpdateAsyncObject_WhenPropertiesIsNotNull_ThenOpdateIsListEntitiesFromDB()
        {
            // Arrange
            var addingInspector = new Inspector { Name = "Rafalsky D." };

            // Act
            await _repository.AddAsync(addingInspector);
            addingInspector.Name = "Kavalsky F.";
            var inspectorUpdate = await _repository.UpdateAsync(addingInspector);
            var entitiesInspector = (await _repository.GetByIdAsync(inspectorUpdate.Id)).ToList().FirstOrDefault();

            //Assert
            entitiesInspector.Should().Be(inspectorUpdate);
            await _repository.DeleteAsync(addingInspector);
        }

        [Test]
        public async Task GetByIdAsyncObject_WhenPropertiesIsNotNull_ThenDeleteIsListEntitiesFromDB()
        {
            //Arrange
            var addingInspector = new Inspector { Name = "Rafalsky D." };

            //Act
            await _repository.AddAsync(addingInspector);
            var entitiesInspector = (await _repository.GetByIdAsync(addingInspector.Id)).ToList().FirstOrDefault();

            //Assert
            entitiesInspector.Should().Be(addingInspector);
            await _repository.DeleteAsync(addingInspector);
        }

        [Test]
        public async Task DeleteAsyncObject_WhenPropertiesIsNotNull_ThenDeleteIsListEntitiesFromDB()
        {
            //Arrange
            var deleteInspector = new Inspector { Name = "Kavalsky P." };

            //Act
            var inspectorAdded = await _repository.AddAsync(deleteInspector);
            await _repository.DeleteAsync(inspectorAdded);
            var entitiesInspector = await _repository.GetByIdAsync(deleteInspector.Id);
            
            //Assert
            entitiesInspector.Should().BeEmpty();
        }

    }
}