using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Models;

namespace AccountingForPotentiallyDangObj.IntegrationTests
{
    public class Tests
    {
        private AfPdoDbContext _tmContext;
        private AfPdoRepository<Inspector> _entityRepository;
        private AfPdoRepository<TypeOfPdo> _typeRepository;
        private AfPdoRepository<JournalPDO> _journalRepository;
        [OneTimeSetUp]
        public void OneTimeSetUp() 
        {
            _tmContext = new AfPdoDbContext("Data Source=ALIVAN\\SQLEXPRESS;Initial Catalog=AccountingForPotentiallyDangObj.DataBase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False");
        }
        [SetUp]
        public void InitialiseTestsEntities()
        {
            _entityRepository = new AfPdoRepository<Inspector>(_tmContext);
            _typeRepository = new AfPdoRepository<TypeOfPdo>(_tmContext);
            _journalRepository = new AfPdoRepository<JournalPDO>(_tmContext);
        }

        [Test]
        public void Test1()
        {
            // Arrange

            // Act
            var entities = _entityRepository.GetAllAsync().Result;
            var entitiesType = _typeRepository.GetAllAsync().Result;
            var entitiesJournal = _journalRepository.GetAllAsync().Result;

            // Assert
            Assert.Pass();
        }

    }
}