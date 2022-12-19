using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Models;

namespace AccountingForPotentiallyDangObj.IntegrationTests
{
    public class AfPdoRepositoryPDOTests
    {
        private AfPdoDbContext _tmContext;
        private AfPdoRepository<PDO> _pdoRepository;
        private DateTime _date1, _date2;

        [OneTimeSetUp]
        public void OneTimeSetUp() 
        {
            _tmContext = new AfPdoDbContext("Data Source=ALIVAN\\SQLEXPRESS;Initial Catalog=AccountingForPotentiallyDangObj.DataBase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False");
        }
        [SetUp]
        public void InitialiseTestsEntities()
        {
            _pdoRepository = new AfPdoRepository<PDO>(_tmContext);
        }

        [Test]
        public void PDOTest()
        {
            // Arrange
            PDO expectedObj1 = new PDO();
            expectedObj1.Id = 1;
            expectedObj1.JournalPdoId = 2;
            expectedObj1.RegistrationNumber = 1;
            expectedObj1.TypeId = 10;
            expectedObj1.DateOfRegistration = new DateTime(2022, 12, 15);
            expectedObj1.YearOfManufacture = 2022;
            expectedObj1.TechnicalSpecificationId = 1;
            expectedObj1.ServiceLife = 25;

            PDO expectedObj2 = new PDO();
            expectedObj2.Id = 2;
            expectedObj2.JournalPdoId = 1;
            expectedObj2.RegistrationNumber = 1;
            expectedObj2.TypeId = 1;
            expectedObj2.DateOfRegistration = new DateTime(2022, 12, 05);
            expectedObj2.YearOfManufacture = 2010;
            expectedObj2.TechnicalSpecificationId = 2;
            expectedObj2.ServiceLife = 10;

            List<PDO> expected = new List<PDO>()
            {
                expectedObj1,
                expectedObj2
            };

            // Act
            var entitiesPDO = _pdoRepository.GetAllAsync().Result;

            // Assert
            Assert.AreEqual(expected, entitiesPDO);
        }

    }
}