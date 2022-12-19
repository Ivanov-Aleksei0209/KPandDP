using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Models;

namespace AccountingForPotentiallyDangObj.IntegrationTests
{
    public class AfPdoRepositoryJournalPDOTests
    {
        private AfPdoDbContext _tmContext;
        private AfPdoRepository<JournalPDO> _journalRepository;
        
        [OneTimeSetUp]
        public void OneTimeSetUp() 
        {
            _tmContext = new AfPdoDbContext("Data Source=ALIVAN\\SQLEXPRESS;Initial Catalog=AccountingForPotentiallyDangObj.DataBase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False");
        }
        [SetUp]
        public void InitialiseTestsEntities()
        {
            _journalRepository = new AfPdoRepository<JournalPDO>(_tmContext);            
        }

        [Test]
        public void JournalPDOTest()
        {
            // Arrange
            JournalPDO expectedObj1 = new JournalPDO();
            expectedObj1.Id = 1;
            expectedObj1.Name = "LiftingCranes";
            expectedObj1.JournalNumber = 31;

            JournalPDO expectedObj2 = new JournalPDO();
            expectedObj2.Id = 2;
            expectedObj2.Name = "Lifts";
            expectedObj2.JournalNumber = 32;

            JournalPDO expectedObj3 = new JournalPDO();
            expectedObj3.Id = 3;
            expectedObj3.Name = "Escalators";
            expectedObj3.JournalNumber = 33;

            JournalPDO expectedObj4 = new JournalPDO();
            expectedObj4.Id = 4;
            expectedObj4.Name = "Elevators";
            expectedObj4.JournalNumber = 34;

            JournalPDO expectedObj5 = new JournalPDO();
            expectedObj5.Id = 5;
            expectedObj5.Name = "Attractions";
            expectedObj5.JournalNumber = 36;



            List<JournalPDO> expected = new List<JournalPDO>()
            {
                expectedObj1,
                expectedObj2,
                expectedObj3,
                expectedObj4,
                expectedObj5
            };

            // Act
            var entitiesJournalPDO = _journalRepository.GetAllAsync().Result;

            // Assert
            Assert.AreEqual(expected, entitiesJournalPDO);
        }

    }
}