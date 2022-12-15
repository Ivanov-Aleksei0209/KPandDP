using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using System.Collections;

namespace AccountingForPotentiallyDangObj.IntegrationTests
{
    public class AfPdoRepositoryTechnicalSpecificationTests
    {
        private AfPdoDbContext _tmContext;
        private AfPdoRepository<TechnicalSpecification> _technicalSpecificationRepository;

        [OneTimeSetUp]
        public void OneTimeSetUp() 
        {
            _tmContext = new AfPdoDbContext("Data Source=ALIVAN\\SQLEXPRESS;Initial Catalog=AccountingForPotentiallyDangObj.DataBase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False");
        }
        [SetUp]
        public void InitialiseTestsEntities()
        {
            _technicalSpecificationRepository = new AfPdoRepository<TechnicalSpecification>(_tmContext);
        }

        [Test]
        public void Test1()
        {
            // Arrange
            TechnicalSpecification expectedObj1 = new TechnicalSpecification();
            expectedObj1.Id = 1;
            expectedObj1.Capacity = 500;
            expectedObj1.ArrowDeparture = 0;
            expectedObj1.Speed = 1.0;
            expectedObj1.NumberOfStops = 9;

            TechnicalSpecification expectedObj2 = new TechnicalSpecification();
            expectedObj2.Id = 2;
            expectedObj2.Capacity = 25;
            expectedObj2.ArrowDeparture = 18.5;
            expectedObj2.Speed = 0;
            expectedObj2.NumberOfStops = 0;

            List<TechnicalSpecification> expected = new List<TechnicalSpecification>()
            {
                expectedObj1,
                expectedObj2
            };

            // Act
            var entitiesTechnicalSpecification = _technicalSpecificationRepository.GetAllAsync().Result;

            // Assert
            Assert.AreEqual(expected, entitiesTechnicalSpecification);
        }

    }
} 