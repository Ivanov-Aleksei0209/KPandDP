using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using FluentAssertions;

namespace AccountingForPotentiallyDangObj.IntegrationTests
{
    [TestFixture]
    public class AfPdoRepositoryInspectorTests : BaseTest<Inspector>
    {
        private AfPdoDbContext _tmContext;
        private AfPdoRepository<Inspector> _inspectorRepository;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _tmContext = new AfPdoDbContext("Data Source=ALIVAN\\SQLEXPRESS;Initial Catalog=AccountingForPotentiallyDangObj.DataBase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False");
        }
        [SetUp]
        public void InitialiseTestsEntities()
        {
            _inspectorRepository = new AfPdoRepository<Inspector>(_tmContext);
        }


        [Test]
        public async Task GetAllAsyncObjects_WhenPropertiesIsNotNull_ThenOutListEntitiesFromDB() // переназвать все первые тесты
        {
            // Arrange
            Inspector expectedObj1 = new Inspector() { Name = "Golovko I." };


            // Act
            var inspectorAdded = await _inspectorRepository.AddAsync(expectedObj1);
            var addedInspector = await _inspectorRepository.GetAllAsync();
            var entitiesInspector = addedInspector.ToList().Where(x => x.Id == expectedObj1.Id).FirstOrDefault();

            // Assert
            expectedObj1.Should().Be(entitiesInspector);
            await _inspectorRepository.DeleteAsync(expectedObj1);
        }

        [Test]
        public async Task AddAsyncObject_WhenPropertiesIsNotNull_ThenOutIsListEntitiesFromDB()
        {
            // Arrange
            var addingInspector = new Inspector { Name = "Rafalsky D." };

            // Act
            await _inspectorRepository.AddAsync(addingInspector);
            var addedInspector = (await _inspectorRepository.GetByIdAsync(addingInspector.Id)).ToList().FirstOrDefault();

            //Assert
            addedInspector.Should().Be(addingInspector);
            await _inspectorRepository.DeleteAsync(addingInspector);
        }

        [Test]
        public async Task UpdateAsyncObject_WhenPropertiesIsNotNull_ThenOpdateIsListEntitiesFromDB()
        {
            // Arrange
            var addingInspector = new Inspector { Name = "Rafalsky D." };

            // Act
            await _inspectorRepository.AddAsync(addingInspector);
            addingInspector.Name = "Kavalsky F.";
            var inspectorUpdate = await _inspectorRepository.UpdateAsync(addingInspector);
            var entitiesInspector = (await _inspectorRepository.GetByIdAsync(inspectorUpdate.Id)).ToList().FirstOrDefault();

            //Assert
            entitiesInspector.Should().Be(inspectorUpdate);
            await _inspectorRepository.DeleteAsync(addingInspector);
        }


        [Test]
        public async Task GetByIdAsyncObject_WhenPropertiesIsNotNull_ThenDeleteIsListEntitiesFromDB()
        {
            //Arrange
            var addingInspector = new Inspector { Name = "Rafalsky D." };

            //Act
            await _inspectorRepository.AddAsync(addingInspector);
            var entitiesInspector = (await _inspectorRepository.GetByIdAsync(addingInspector.Id)).ToList().FirstOrDefault();

            //Assert
            entitiesInspector.Should().Be(addingInspector);
            await _inspectorRepository.DeleteAsync(addingInspector);
        }

        [Test]
        public async Task DeleteAsyncObject_WhenPropertiesIsNotNull_ThenDeleteIsListEntitiesFromDB()
        {
            //Arrange
            var deleteInspector = new Inspector { Name = "Kavalsky P." };

            //Act
            var inspectorAdded = await _inspectorRepository.AddAsync(deleteInspector);
            await _inspectorRepository.DeleteAsync(inspectorAdded);
            var entitiesInspector = await _inspectorRepository.GetByIdAsync(deleteInspector.Id);
            
            //Assert
            entitiesInspector.Should().BeEmpty();
        }

    }
}