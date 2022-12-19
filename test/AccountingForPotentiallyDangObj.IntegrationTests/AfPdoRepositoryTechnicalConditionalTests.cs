using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Models;

namespace AccountingForPotentiallyDangObj.IntegrationTests
{
    public class AfPdoRepositoryTechnicalConditionalTests
    {
        private AfPdoDbContext _tmContext;
        private AfPdoRepository<TechnicalConditional> _technicalConditionalRepository;

        [OneTimeSetUp]
        public void OneTimeSetUp() 
        {
            _tmContext = new AfPdoDbContext("Data Source=ALIVAN\\SQLEXPRESS;Initial Catalog=AccountingForPotentiallyDangObj.DataBase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False");
        }
        [SetUp]
        public void InitialiseTestsEntities()
        {
            _technicalConditionalRepository = new AfPdoRepository<TechnicalConditional>(_tmContext);
        }

        [Test]
        public void TechnicalConditionalTest()
        {
            // Arrange
            TechnicalConditional expectedObj1 = new TechnicalConditional();
            expectedObj1.Id = 1;
            expectedObj1.Name = "OperatedBy";

            TechnicalConditional expectedObj2 = new TechnicalConditional();
            expectedObj2.Id = 2;
            expectedObj2.Name = "NotOperated";

            TechnicalConditional expectedObj3 = new TechnicalConditional();
            expectedObj3.Id = 3;
            expectedObj3.Name = "Banned";

            TechnicalConditional expectedObj4 = new TechnicalConditional();
            expectedObj4.Id = 4;
            expectedObj4.Name = "UnderRepair";

            List<TechnicalConditional> expected = new List<TechnicalConditional>()
            {
                expectedObj1,
                expectedObj2,
                expectedObj3,
                expectedObj4
            };

            // Act
            var entitiesTechnicalConditional = _technicalConditionalRepository.GetAllAsync().Result;

            // Assert
            Assert.AreEqual(expected, entitiesTechnicalConditional);
        }

    }
}