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
        public void SubjectTest()
        {
            // Arrange
            Subject expectedObj1 = new Subject();
            expectedObj1.Id = 1;
            expectedObj1.Name = "Delta";
            expectedObj1.UNP = 490124456;
            expectedObj1.departmentalAffiliationId = 7;
            expectedObj1.postalAddress = "Trudovaya str, 39A, Borschovka, Rechica region";
            expectedObj1.phone = "8-029-457-78-98";

            Subject expectedObj2 = new Subject();
            expectedObj2.Id = 2;
            expectedObj2.Name = "Centralnoye";
            expectedObj2.UNP = 490000011;
            expectedObj2.departmentalAffiliationId = 1;
            expectedObj2.postalAddress = "Telmana st, 26A, Gomel";
            expectedObj2.phone = "8-0232-50-50-02";

            List<Subject> expected = new List<Subject>()
            {
                expectedObj1,
                expectedObj2
            };

            // Act
            var entitiesSubject = _subjectRepository.GetAllAsync().Result;

            // Assert
            Assert.AreEqual(expected, entitiesSubject);
        }

    }
}