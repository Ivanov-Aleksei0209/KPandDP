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
        public void Test1()
        {
            // Arrange

            // Act
            var entitiesJournal = _journalRepository.GetAllAsync().Result;

            // Assert
            Assert.Pass();
        }

    }
}