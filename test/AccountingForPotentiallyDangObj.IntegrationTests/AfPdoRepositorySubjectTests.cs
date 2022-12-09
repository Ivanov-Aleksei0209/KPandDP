using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Models;

namespace AccountingForPotentiallyDangObj.IntegrationTests
{
    public class AfPdoRepositorySubjectTests
    {
        private AfPdoDbContext _tmContext;
        private AfPdoRepository<Subject> _subjectRepository;

        [OneTimeSetUp]
        public void OneTimeSetUp() 
        {
            _tmContext = new AfPdoDbContext("Data Source=ALIVAN\\SQLEXPRESS;Initial Catalog=AccountingForPotentiallyDangObj.DataBase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False");
        }
        [SetUp]
        public void InitialiseTestsEntities()
        {
            _subjectRepository = new AfPdoRepository<Subject>(_tmContext);
        }

        [Test]
        public void Test1()
        {
            // Arrange

            // Act
            var entitiesSubject = _subjectRepository.GetAllAsync().Result;


            // Assert
            Assert.Pass();
        }

    }
}