using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Models;

namespace AccountingForPotentiallyDangObj.IntegrationTests
{
    public class AfPdoRepositoryInspectorTests
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
        public void InspectorTest()
        {
            // Arrange
            Inspector expectedObj1 = new Inspector();
            expectedObj1.Id = 1;
            expectedObj1.Name = "Ivanov A.";

            Inspector expectedObj2 = new Inspector();
            expectedObj2.Id = 2;
            expectedObj2.Name = "Koncevoi S.";

            Inspector expectedObj3 = new Inspector();
            expectedObj3.Id = 3;
            expectedObj3.Name = "Poltorak A.";

            Inspector expectedObj4 = new Inspector();
            expectedObj4.Id = 4;
            expectedObj4.Name = "Smolovik G.";

            List<Inspector> expected = new List<Inspector>()
            {
                expectedObj1,
                expectedObj2,
                expectedObj3,
                expectedObj4
            };

            // Act
            var entitiesInspector = _inspectorRepository.GetAllAsync().Result;

            // Assert
            Assert.AreEqual(expected, entitiesInspector);

        }
    }
}