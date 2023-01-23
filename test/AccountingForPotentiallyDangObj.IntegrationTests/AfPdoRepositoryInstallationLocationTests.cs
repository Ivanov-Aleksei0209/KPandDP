using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Models;

namespace AccountingForPotentiallyDangObj.IntegrationTests
{
    public class AfPdoRepositoryInstallationLocationTests
    {
        private AfPdoDbContext _tmContext;
        private AfPdoRepository<InstallationLocation> _installationLocationRepository;

        [OneTimeSetUp]
        public void OneTimeSetUp() 
        {
            _tmContext = new AfPdoDbContext("Data Source=ALIVAN\\SQLEXPRESS;Initial Catalog=AccountingForPotentiallyDangObj.DataBase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False");
        }
        [SetUp]
        public void InitialiseTestsEntities()
        {
            _installationLocationRepository = new AfPdoRepository<InstallationLocation>(_tmContext);
        }

        [Test, Order(1)]
        public void GetAllAsyncObjects_WhenPropertiesIsNotNull_ThenOutListEntitiesFromDB()
        {
            // Arrange
            InstallationLocation expectedObj1 = new InstallationLocation();
            expectedObj1.Id = 1;
            expectedObj1.Name = "housingStock";

            InstallationLocation expectedObj2 = new InstallationLocation();
            expectedObj2.Id = 2;
            expectedObj2.Name = "dormitory";

            InstallationLocation expectedObj3 = new InstallationLocation();
            expectedObj3.Id = 3;
            expectedObj3.Name = "healthcareInstitution";

            InstallationLocation expectedObj4 = new InstallationLocation();
            expectedObj4.Id = 4;
            expectedObj4.Name = "institutionEducation";

            InstallationLocation expectedObj5 = new InstallationLocation();
            expectedObj5.Id = 5;
            expectedObj5.Name = "administrativeBuilding";

            InstallationLocation expectedObj6 = new InstallationLocation();
            expectedObj6.Id = 6;
            expectedObj6.Name = "productionBuilding";

            InstallationLocation expectedObj7 = new InstallationLocation();
            expectedObj7.Id = 7;
            expectedObj7.Name = "constructionSite";

            List<InstallationLocation> expected = new List<InstallationLocation>()
            {
                expectedObj1,
                expectedObj2,
                expectedObj3,
                expectedObj4,
                expectedObj5,
                expectedObj6,
                expectedObj7
            };

            // Act
            var entitiesInstallationLocation = _installationLocationRepository.GetAllAsync().Result;

            // Assert
            Assert.AreEqual(expected, entitiesInstallationLocation);
        }


    }
}